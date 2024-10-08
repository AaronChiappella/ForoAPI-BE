using FluentValidation.AspNetCore;
using ForoAPI.Application.Interfaces;
using ForoAPI.Application.Mappers;
using ForoAPI.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ForoAPI.Application.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration) // Updated method name
        {
            services.AddSingleton(configuration);

            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic));
            });


            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IUserApplication, UserApplication>();
           


            return services;
        }
    }
}
