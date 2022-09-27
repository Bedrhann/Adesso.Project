using Adesso.Project.Application.Interfaces.Services.TokenServices;
using Adesso.Project.Application.Models.JwtToken;
using Adesso.Project.Application.Wrappers.Response;
using Adesso.Project.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Serilog;
using System.Security.Claims;

namespace Adesso.Project.Application.Features.UserFeatues.Commands.CheckUser
{
    public class CheckUserCommandHandler : IRequestHandler<CheckUserCommandRequest, BaseResponse<Token>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IGenerateToken _tokenGenerater;

        public CheckUserCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IGenerateToken tokenGenerater)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenGenerater = tokenGenerater;
        }

        public async Task<BaseResponse<Token>> Handle(CheckUserCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<Claim> claims = new List<Claim>();
                if (request.Email == "admin" && request.Password == "admin")//eğer admin girişi yapılırsa ona rolünü belirtiyoruz ve token dönüyoruz.
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    claims.Add(new Claim("Id", "0"));
                    Token token1 = _tokenGenerater.CreateAccessToken(5, claims);
                    return new BaseResponse<Token>(token1);
                }

                AppUser user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null)
                    return new BaseResponse<Token>("Wrong Password or Email");

                SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
                if (result.Succeeded) //Authentication başarılı!
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    foreach (var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }
                    claims.Add(new Claim("Id", user.Id));
                    Token token = _tokenGenerater.CreateAccessToken(5, claims);
                }
                return new BaseResponse<Token>("Wrong Password or Email");
            }
            catch (Exception ex)
            {
                Log.Error("CheckUserCommandHandler", ex);
                return new BaseResponse<Token>(ex.Message);
            }










        }
    }
}
