using AutoMapper;
using Ubus.App.ViewModels;
using Ubus.Business.Entities;

namespace Ubus.App.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Bus, BusViewModel>();
            CreateMap<MiniBar, MiniBarViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Route, RouteViewModel>();
            CreateMap<Driver, DriverViewModel>();
            CreateMap<Trip, TripViewModel>();
        }
    }
}
