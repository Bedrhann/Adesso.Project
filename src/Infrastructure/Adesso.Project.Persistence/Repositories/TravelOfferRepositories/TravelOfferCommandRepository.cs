using Adesso.Project.Application.Interfaces.Repositories.TravelOfferRepositories;
using Adesso.Project.Domain.Entities;
using Adesso.Project.Persistence.Context;
using Adesso.Project.Persistence.Repositories.Common;

namespace Adesso.Project.Persistence.Repositories.TravelOfferRepositories
{
    public class TravelOfferCommandRepository : CommandRepository<TravelOffer>, ITravelOfferCommandRepository
    {
        public TravelOfferCommandRepository(PostgreSqlDbContext context) : base(context)
        {
        }
    }
}
