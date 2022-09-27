using Adesso.Project.Application.DTOs.UserDTOs;
using Adesso.Project.Application.Wrappers.Response;
using MediatR;

namespace Adesso.Project.Application.Features.UserFeatues.Commands.CreateUser
{
    public class CreateUserCommandRequest : IRequest<BaseResponse<GetUserDto>>
    {
        public CreateUserDto CreateUserDto { get; set; }
    }
}
