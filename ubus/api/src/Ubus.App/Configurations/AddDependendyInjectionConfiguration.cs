using Microsoft.Extensions.DependencyInjection;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Data.Context;
using Ubus.Data.Repositories;

namespace Ubus.App.Configurations
{
    public static class AddDependendyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped<TripContext>();

            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IBusRepository, BusRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<ITripRepository, TripRepository>();
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IAdditionalRepository, AdditionalRepository>();

            return services;
        }
    }
}
