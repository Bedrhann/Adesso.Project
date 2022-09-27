using Adesso.Project.Application.DTOs.UserDTOs;
using Adesso.Project.Application.Wrappers.Response;
using Adesso.Project.Domain.Entities.Identity;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Serilog;

namespace Adesso.Project.Application.Features.UserFeatues.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, BaseResponse<GetUserDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public CreateUserCommandHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<BaseResponse<GetUserDto>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                 List<AppUser> List = _userManager.Users.ToList();
                if(List.Count<1)
                {
                    await _roleManager.CreateAsync(new AppRole { Id = "sdfsdfsfs", Name = "Admin" });
                    await _roleManager.CreateAsync(new AppRole { Id = "dfsdffsf", Name = "User" });
                }
                AppUser NewUser = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = request.CreateUserDto.UserName,
                    FirstName = request.CreateUserDto.FirstName,
                    LastName = request.CreateUserDto.LastName,
                    Email = request.CreateUserDto.Email,
                    RegistrationDate = DateTime.UtcNow,
                };
               
                IdentityResult result = await _userManager.CreateAsync(NewUser, request.CreateUserDto.Password);
                await _userManager.AddToRoleAsync(NewUser, "User");

                return new BaseResponse<GetUserDto>(request.CreateUserDto.Adapt<GetUserDto>());
            }
            catch (Exception ex)
            {
                Log.Error("CreateUserCommandHandler", ex);
                return new BaseResponse<GetUserDto>(ex.Message);
            }
        }
    }
}
