using AutoMapper;
using Ubus.App.Commands.Trip;
using Ubus.App.ViewModels;
using Ubus.Business.Entities;

namespace Ubus.App.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Bus, BusViewModel>().ReverseMap();
            CreateMap<Route, RouteViewModel>().ReverseMap();
            CreateMap<Driver, DriverViewModel>().ReverseMap();
            CreateMap<Trip, TripViewModel>().ReverseMap();
            CreateMap<Additional, AdditionalViewModel>().ReverseMap();

            CreateMap<Trip, CreateTripCommand>();
            CreateMap<CreateTripCommand, Trip>();
        }
    }
}
