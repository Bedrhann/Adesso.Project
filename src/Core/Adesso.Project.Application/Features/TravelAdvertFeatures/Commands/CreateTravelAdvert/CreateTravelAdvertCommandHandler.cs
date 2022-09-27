using Adesso.Project.Application.DTOs.TravelAdvertDTOs;
using Adesso.Project.Application.Interfaces.Repositories.TravelAdvertRepositories;
using Adesso.Project.Application.Wrappers.Response;
using Adesso.Project.Domain.Entities;
using Mapster;
using MediatR;
using Serilog;

namespace Adesso.Project.Application.Features.TravelAdvertFeatures.Commands.CreateTravelAdvert
{
    public class CreateTravelAdvertCommandHandler : IRequestHandler<CreateTravelAdvertCommandRequest, BaseResponse<GetTravelAdvertDto>>
    {

        private readonly ITravelAdvertCommandRepository _repository;

        public CreateTravelAdvertCommandHandler(ITravelAdvertCommandRepository repository)
        {
            _repository = repository;
        }
        public async Task<BaseResponse<GetTravelAdvertDto>> Handle(CreateTravelAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                TravelAdvert travelAdvert = request.GetTravelAdvertDto.Adapt<TravelAdvert>();
                await _repository.AddAsync(travelAdvert);
                await _repository.SaveAsync();

                return new BaseResponse<GetTravelAdvertDto>(request.GetTravelAdvertDto);
            }
            catch (Exception ex)
            {
                Log.Error("CreateProductCommandHandler", ex);
                return new BaseResponse<GetTravelAdvertDto>(ex.Message);
            }
        }
    }
}
