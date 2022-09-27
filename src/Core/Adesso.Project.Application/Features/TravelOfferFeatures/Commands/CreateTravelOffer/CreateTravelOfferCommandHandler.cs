using Adesso.Project.Application.DTOs.TravelOfferDTOs;
using Adesso.Project.Application.Interfaces.Repositories.TravelAdvertRepositories;
using Adesso.Project.Application.Interfaces.Repositories.TravelOfferRepositories;
using Adesso.Project.Application.Wrappers.Response;
using Adesso.Project.Domain.Entities;
using Mapster;
using MediatR;
using Serilog;

namespace Adesso.Project.Application.Features.TravelOfferFeatures.Commands.CreateTravelOffer
{
    public class CreateTravelOfferCommandHandler : IRequestHandler<CreateTravelOfferCommandRequest, BaseResponse<GetTravelOfferDto>>
    {

        private readonly ITravelOfferCommandRepository _travelOfferCommandRepository;
        private readonly ITravelAdvertQueryRepository _travelAdvertQueryRepository;

        public CreateTravelOfferCommandHandler(ITravelOfferCommandRepository travelOfferCommandRepository, ITravelAdvertQueryRepository travelAdvertQueryRepository)
        {
            _travelOfferCommandRepository = travelOfferCommandRepository;
            _travelAdvertQueryRepository = travelAdvertQueryRepository;
        }
        public async Task<BaseResponse<GetTravelOfferDto>> Handle(CreateTravelOfferCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                TravelAdvert travelAdvert = await _travelAdvertQueryRepository.GetByIdAsync(request.GetTravelOfferDto.TravelAdvertId.ToString());
                if (travelAdvert.NumberOfSeat < 1)
                    return new BaseResponse<GetTravelOfferDto>("There are no empty seats in this vehicle.");

                TravelOffer travelOffer = request.GetTravelOfferDto.Adapt<TravelOffer>();
                await _travelOfferCommandRepository.AddAsync(travelOffer);
                await _travelOfferCommandRepository.SaveAsync();

                return new BaseResponse<GetTravelOfferDto>(request.GetTravelOfferDto);
            }
            catch (Exception ex)
            {
                Log.Error("CreateTravelOfferCommandHandler", ex);
                return new BaseResponse<GetTravelOfferDto>(ex.Message);
            }
        }
    }
}
