using Adesso.Project.Application.Interfaces.Repositories.TravelAdvertRepositories;
using Adesso.Project.Domain.Entities;
using Adesso.Project.Persistence.Context;
using Adesso.Project.Persistence.Repositories.Common;

namespace Adesso.Project.Persistence.Repositories.TravelAdvertRepositories
{
    public class TravelAdvertQueryRepository : QueryRepository<TravelAdvert>, ITravelAdvertQueryRepository
    {
        public TravelAdvertQueryRepository(PostgreSqlDbContext context) : base(context)
        {
        }
    }
}
