using Adesso.Project.Application.DTOs.TravelOfferDTOs;
using Adesso.Project.Application.Features.TravelOfferFeatures.Commands.AcceptTravelOffer;
using Adesso.Project.Application.Features.TravelOfferFeatures.Commands.CreateTravelOffer;
using Adesso.Project.Application.Wrappers.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Adesso.Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelOffersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TravelOffersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("{offerId}/accept")]
        public async Task<IActionResult> AcceptOffer([FromRoute] string offerId)
        {
            //ClaimsIdentity Identity = (ClaimsIdentity)HttpContext.User.Identity;//Kaçak girişleri engellemek için kullanıcının ıd bilgisini token içinden cekiyoruz.
            //int OwnerId = Int32.Parse(Identity.Claims.FirstOrDefault(x => x.Type == "Id").Value);
            AcceptTravelOfferCommandRequest request = new()
            {
                OfferId = Guid.Parse(offerId),
                OwnerId = Guid.Parse("0c4c8b46-0cf7-4062-a4e2-38cc719d4a43")
            };
            BaseResponse<GetTravelOfferDto> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTravelOffer([FromBody] CreateTravelOfferCommandRequest request)
        {
            BaseResponse<GetTravelOfferDto> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
