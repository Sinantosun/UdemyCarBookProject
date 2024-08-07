using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UdemyCarBook.Application.Services
{
    public static class ServiceRegistiration
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));
        }
    }
}
