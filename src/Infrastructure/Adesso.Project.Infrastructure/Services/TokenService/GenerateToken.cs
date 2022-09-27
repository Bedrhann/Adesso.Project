using Adesso.Project.Application.Interfaces.Services.TokenServices;
using Adesso.Project.Application.Models.JwtToken;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Adesso.Project.Infrastructure.Services.TokenService
{
    public class GenerateToken : IGenerateToken
    {
        readonly IConfiguration _configuration;

        public GenerateToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateAccessToken(int minute, List<Claim> claims)
        {

            Token token = new();

            //Security Key'in simetriğini alıyoruz.
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            //Şifrelenmiş kimliği oluşturuyoruz.
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            //Oluşturulacak token ayarlarını veriyoruz.
            token.TokenLifeTime = DateTime.UtcNow.AddDays(3);//TODO burası değişken olacak
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.TokenLifeTime,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials,
                claims: claims
                );
            //TODO yorumlar kontrol
            //Token oluşturucu sınıfından bir örnek alalım.
            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
