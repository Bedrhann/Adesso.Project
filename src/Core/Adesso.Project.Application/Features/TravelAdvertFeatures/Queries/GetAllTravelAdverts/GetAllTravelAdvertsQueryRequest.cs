using Adesso.Project.Application.Wrappers.Paging;
using MediatR;

namespace Adesso.Project.Application.Features.TravelAdvertFeatures.Queries.GetAllTravelAdverts
{
    public class GetAllTravelAdvertsQueryRequest : BasePagingRequest, IRequest<GetAllTravelAdvertsQueryResponse>
    {
        public string? SearchByStartingCity { get; set; }
        public string? SearchByDestinationCity { get; set; }

    }
}
