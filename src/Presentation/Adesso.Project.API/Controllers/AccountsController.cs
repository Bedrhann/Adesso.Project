using Adesso.Project.Application.DTOs.UserDTOs;
using Adesso.Project.Application.Features.UserFeatues.Commands.CheckUser;
using Adesso.Project.Application.Features.UserFeatues.Commands.CreateUser;
using Adesso.Project.Application.Wrappers.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adesso.Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommandRequest request)
        {
            BaseResponse<GetUserDto> response = await _mediator.Send(request);
            return Ok(response);
        }

        //[HttpPost("login")]
        //public async Task<IActionResult> CheckUser([FromBody] CheckUserCommandRequest request)
        //{
        //    BaseResponse<GetUserDto> response = await _mediator.Send(request);
        //    return Ok(response);
        //}
    }
}
