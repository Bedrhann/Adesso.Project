using Adesso.Project.Application.DTOs.TravelOfferDTOs;
using Adesso.Project.Application.Interfaces.Repositories.TravelAdvertRepositories;
using Adesso.Project.Application.Interfaces.Repositories.TravelOfferRepositories;
using Adesso.Project.Application.Wrappers.Response;
using Adesso.Project.Domain.Entities;
using Mapster;
using MediatR;
using Serilog;

namespace Adesso.Project.Application.Features.TravelOfferFeatures.Commands.AcceptTravelOffer
{
    public class AcceptTravelOfferCommandHandler : IRequestHandler<AcceptTravelOfferCommandRequest, BaseResponse<GetTravelOfferDto>>
    {
        private readonly ITravelOfferQueryRepository _travelOfferQueryRepository;
        private readonly ITravelOfferCommandRepository _travelOfferCommandRepository;
        private readonly ITravelAdvertCommandRepository _travelAdvertCommandRepository;
        private readonly ITravelAdvertQueryRepository _travelAdvertQueryRepository;

        public AcceptTravelOfferCommandHandler(ITravelOfferQueryRepository travelOfferQueryRepository, ITravelOfferCommandRepository travelOfferCommandRepository, ITravelAdvertCommandRepository travelAdvertCommandRepository, ITravelAdvertQueryRepository travelAdvertQueryRepository)
        {
            _travelOfferQueryRepository = travelOfferQueryRepository;
            _travelOfferCommandRepository = travelOfferCommandRepository;
            _travelAdvertCommandRepository = travelAdvertCommandRepository;
            _travelAdvertQueryRepository = travelAdvertQueryRepository;
        }

        public async Task<BaseResponse<GetTravelOfferDto>> Handle(AcceptTravelOfferCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                TravelOffer travelOffer = await _travelOfferQueryRepository.GetByIdAsync(request.OfferId.ToString());
                if (travelOffer is null)
                {
                    return new BaseResponse<GetTravelOfferDto>("Record Not Found");
                }

                travelOffer.TravelAdvert = await _travelAdvertQueryRepository.GetByIdAsync(travelOffer.TravelAdvertId.ToString());
                if (travelOffer.TravelAdvert.NumberOfSeat < 1)
                    return new BaseResponse<GetTravelOfferDto>("There are no empty seats in this vehicle.");

                if (travelOffer.TravelAdvert.AppUserId != request.OwnerId.ToString())
                {
                    return new BaseResponse<GetTravelOfferDto>("unauthorized action");
                }
                travelOffer.OfferStatus = "Accepted";
                travelOffer.TravelAdvert.NumberOfSeat--;
                _travelAdvertCommandRepository.Update(travelOffer.TravelAdvert);
                await _travelAdvertCommandRepository.SaveAsync();

                return new BaseResponse<GetTravelOfferDto>(travelOffer.Adapt<GetTravelOfferDto>());
            }
            catch (Exception ex)
            {
                Log.Error("AcceptTravelOfferCommandHandler", ex);
                return new BaseResponse<GetTravelOfferDto>(ex.Message);
            }
        }
    }
}
