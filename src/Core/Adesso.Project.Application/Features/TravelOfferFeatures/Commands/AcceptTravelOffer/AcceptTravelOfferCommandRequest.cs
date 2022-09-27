using Adesso.Project.Application.DTOs.TravelOfferDTOs;
using Adesso.Project.Application.Wrappers.Response;
using MediatR;

namespace Adesso.Project.Application.Features.TravelOfferFeatures.Commands.AcceptTravelOffer
{
    public class AcceptTravelOfferCommandRequest : IRequest<BaseResponse<GetTravelOfferDto>>
    {
        public Guid OwnerId { get; set; }
        public Guid OfferId { get; set; }
    }
}
