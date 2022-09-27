using Adesso.Project.Application.DTOs.TravelAdvertDTOs;
using Adesso.Project.Application.Features.TravelAdvertFeatures.Commands.CreateTravelAdvert;
using Adesso.Project.Application.Features.TravelAdvertFeatures.Queries.GetAllTravelAdverts;
using Adesso.Project.Application.Wrappers.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace Adesso.Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelAdvertsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TravelAdvertsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTravelAdverts([FromQuery] GetAllTravelAdvertsQueryRequest request)
        {
            //ClaimsIdentity Identity = (ClaimsIdentity)HttpContext.User.Identity;
            //request.UserId = Guid.Parse(Identity.Claims.FirstOrDefault(x => x.Type == "Id").Value);

            GetAllTravelAdvertsQueryResponse response = await _mediator.Send(request);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.PagingInfo));
            return Ok(response.BaseResponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTravelAdvert([FromBody] CreateTravelAdvertCommandRequest request)
        {
            BaseResponse<GetTravelAdvertDto> response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
