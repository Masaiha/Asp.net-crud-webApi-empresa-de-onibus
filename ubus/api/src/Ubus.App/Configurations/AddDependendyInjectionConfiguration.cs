using Microsoft.Extensions.DependencyInjection;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Interfaces.Services;
using Ubus.Business.Services;
using Ubus.Data.Context;
using Ubus.Data.Repositories;

namespace Ubus.App.Configurations
{
    public static class AddDependendyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped<TripContext>();

            /* Repositories */
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IBusRepository, BusRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<ITripRepository, TripRepository>();
            services.AddScoped<IAdditionalRepository, AdditionalRepository>();

            /* Services */
            services.AddScoped<IRouteService, RouteService>();
            services.AddScoped<IBusService, BusService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<ITripService, TripService>();
            services.AddScoped<IAdditionalService, AdditionalService>();

            return services;
        }
    }
}
