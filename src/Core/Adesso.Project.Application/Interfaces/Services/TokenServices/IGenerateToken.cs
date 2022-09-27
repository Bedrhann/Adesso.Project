using Adesso.Project.Application.Models.JwtToken;
using System.Security.Claims;

namespace Adesso.Project.Application.Interfaces.Services.TokenServices
{
    public interface IGenerateToken
    {
        Token CreateAccessToken(int minute, List<Claim> claims);
    }
}
