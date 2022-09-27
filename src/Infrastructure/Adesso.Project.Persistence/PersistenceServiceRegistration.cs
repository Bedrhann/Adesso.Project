using Adesso.Project.Application.Interfaces.Repositories.TravelAdvertRepositories;
using Adesso.Project.Application.Interfaces.Repositories.TravelOfferRepositories;
using Adesso.Project.Domain.Entities.Identity;
using Adesso.Project.Persistence.Context;
using Adesso.Project.Persistence.Repositories.TravelAdvertRepositories;
using Adesso.Project.Persistence.Repositories.TravelOfferRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Adesso.Project.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<PostgreSqlDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PosgreSqlConnection")));

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<PostgreSqlDbContext>();

            services.AddScoped<ITravelAdvertCommandRepository, TravelAdvertCommandRepository>();
            services.AddScoped<ITravelAdvertQueryRepository, TravelAdvertQueryRepository>();
            services.AddScoped<ITravelOfferCommandRepository, TravelOfferCommandRepository>();
            services.AddScoped<ITravelOfferQueryRepository, TravelOfferQueryRepository>();
        }
    }
}