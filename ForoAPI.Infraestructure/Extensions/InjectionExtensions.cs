using ForoAPI.Infraestructure.Persistance.Context;
using ForoAPI.Infraestructure.Persistance.Interfaces;
using ForoAPI.Infraestructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ForoAPI.Infraestructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Assuming ForoApi.Infraestructure is the name of your assembly
            var assemblyName = typeof(ForoApiDbContext).Assembly.GetName().Name;

            services.AddDbContext<ForoApiDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))); // Use the configuration parameter here

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
