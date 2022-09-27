using Adesso.Project.Application.DTOs.TravelAdvertDTOs;
using Adesso.Project.Application.Interfaces.Repositories.TravelAdvertRepositories;
using Adesso.Project.Application.Models.Paging;
using Adesso.Project.Application.Wrappers.Response;
using Adesso.Project.Domain.Entities;
using Mapster;
using MediatR;
using Serilog;

namespace Adesso.Project.Application.Features.TravelAdvertFeatures.Queries.GetAllTravelAdverts
{
    public class GetAllTravelAdvertsQueryHandler : IRequestHandler<GetAllTravelAdvertsQueryRequest, GetAllTravelAdvertsQueryResponse>
    {
        private readonly ITravelAdvertQueryRepository _repository;

        public GetAllTravelAdvertsQueryHandler(ITravelAdvertQueryRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetAllTravelAdvertsQueryResponse> Handle(GetAllTravelAdvertsQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IQueryable<TravelAdvert> travelAdverts = _repository.GetAll();

                if (!string.IsNullOrWhiteSpace(request.SearchByStartingCity))
                {
                    travelAdverts = travelAdverts.Where(x => x.StartingCity.Contains(request.SearchByStartingCity));
                }
                if (!string.IsNullOrWhiteSpace(request.SearchByDestinationCity))
                {
                    travelAdverts = travelAdverts.Where(x => x.StartingCity.Contains(request.SearchByDestinationCity));
                }

                int TotalUser = travelAdverts.Count();
                int TotalPage = (int)Math.Ceiling(TotalUser / (double)request.Limit);//sayfalama bilgilerini hesaplıyoruz
                int Skip = (request.Page - 1) * request.Limit;

                PagingInfo PageInfo = new()//sayfalama yapısını doldurup ona göre dönüş yapıyoruz.
                {
                    TotalData = TotalUser,
                    TotalPage = TotalPage,
                    PageLimit = request.Limit,
                    PageNum = request.Page,
                    HasNext = request.Page >= TotalPage ? false : true,
                    HasPrevious = request.Page == 1 ? false : true,
                };
                List<TravelAdvert> travelAdvertsList = travelAdverts.Skip(Skip).Take(request.Limit).ToList();
                List<GetTravelAdvertDto> travelAdvertsDtoList = travelAdvertsList.Adapt<List<GetTravelAdvertDto>>();
                return new GetAllTravelAdvertsQueryResponse()
                {
                    BaseResponse = new BaseResponse<List<GetTravelAdvertDto>>(travelAdvertsDtoList),
                    PagingInfo = PageInfo
                };
            }
            catch (Exception ex)
            {
                Log.Error("GetAllProductsQueryHandler", ex);
                return new GetAllTravelAdvertsQueryResponse()
                {
                    BaseResponse = new BaseResponse<List<GetTravelAdvertDto>>(ex.Message),
                };
            }
        }
    }
}
