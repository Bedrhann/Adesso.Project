using Adesso.Project.Application.DTOs.TravelAdvertDTOs;
using Adesso.Project.Application.Wrappers.Response;
using MediatR;

namespace Adesso.Project.Application.Features.TravelAdvertFeatures.Commands.CreateTravelAdvert
{
    public class CreateTravelAdvertCommandRequest : IRequest<BaseResponse<GetTravelAdvertDto>>
    {
        public GetTravelAdvertDto GetTravelAdvertDto { get; set; }
    }
}
