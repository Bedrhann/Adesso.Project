using Adesso.Project.Application.Models.JwtToken;
using Adesso.Project.Application.Wrappers.Response;
using MediatR;

namespace Adesso.Project.Application.Features.UserFeatues.Commands.CheckUser
{
    public class CheckUserCommandRequest : IRequest<BaseResponse<Token>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
