using Adesso.Project.Application.Interfaces.Repositories.TravelAdvertRepositories;
using Adesso.Project.Domain.Entities;
using Adesso.Project.Persistence.Context;
using Adesso.Project.Persistence.Repositories.Common;

namespace Adesso.Project.Persistence.Repositories.TravelAdvertRepositories
{
    public class TravelAdvertCommandRepository : CommandRepository<TravelAdvert>, ITravelAdvertCommandRepository
    {
        public TravelAdvertCommandRepository(PostgreSqlDbContext context) : base(context)
        {
        }
    }
}
