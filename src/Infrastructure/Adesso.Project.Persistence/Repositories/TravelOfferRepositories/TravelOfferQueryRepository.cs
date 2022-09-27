using Adesso.Project.Application.Interfaces.Repositories.TravelOfferRepositories;
using Adesso.Project.Domain.Entities;
using Adesso.Project.Persistence.Context;
using Adesso.Project.Persistence.Repositories.Common;

namespace Adesso.Project.Persistence.Repositories.TravelOfferRepositories
{
    public class TravelOfferQueryRepository : QueryRepository<TravelOffer>, ITravelOfferQueryRepository
    {
        public TravelOfferQueryRepository(PostgreSqlDbContext context) : base(context)
        {
        }
    }
}
