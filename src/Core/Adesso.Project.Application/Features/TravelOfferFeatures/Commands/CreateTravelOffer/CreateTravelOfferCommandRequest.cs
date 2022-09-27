using Adesso.Project.Application.DTOs.TravelOfferDTOs;
using Adesso.Project.Application.Wrappers.Response;
using MediatR;

namespace Adesso.Project.Application.Features.TravelOfferFeatures.Commands.CreateTravelOffer
{
    public class CreateTravelOfferCommandRequest : IRequest<BaseResponse<GetTravelOfferDto>>
    {
        public GetTravelOfferDto GetTravelOfferDto { get; set; }
    }
}
