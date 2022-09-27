using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Adesso.Project.Application
{
    public static class ApplicationServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationServiceRegistration));
        }
    }
}
