using Adesso.Project.Application.DTOs.TravelAdvertDTOs;
using Adesso.Project.Application.Models.Paging;
using Adesso.Project.Application.Wrappers.Response;

namespace Adesso.Project.Application.Features.TravelAdvertFeatures.Queries.GetAllTravelAdverts
{
    public class GetAllTravelAdvertsQueryResponse
    {
        public BaseResponse<List<GetTravelAdvertDto>> BaseResponse { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
