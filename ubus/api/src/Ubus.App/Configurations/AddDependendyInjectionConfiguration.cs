using Microsoft.Extensions.DependencyInjection;
using Ubus.Business.Interfaces.Notifications;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Interfaces.Services;
using Ubus.Business.Notification;
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
            services.AddScoped<IAdditionalRepository, AdditionalRepository>();
            services.AddScoped<IBusRepository, BusRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<ITripDriverRepository, TripDriverRepository>();
            services.AddScoped<ITripRepository, TripRepository>();

            /* Services */
            services.AddScoped<IAdditionalService, AdditionalService>();
            services.AddScoped<IBusService, BusService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IRouteService, RouteService>();
            services.AddScoped<ITripService, TripService>();

            /* Notifications */
            services.AddScoped<INotifier, Notifier>();

            return services;
        }
    }
}
