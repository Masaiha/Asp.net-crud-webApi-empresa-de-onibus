using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ubus.App.ViewModels;
using Ubus.Business.Entities;
using Ubus.Business.Interfaces.Repositories;

namespace Ubus.App.Controllers
{
    [ApiController]
    [Route("teste")]
    public class TesteController : ControllerBase
    {
        private readonly IRouteRepository _route;
        private readonly IBusRepository _bus;
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;
        public TesteController(IRouteRepository route, IBusRepository bus, IMapper mapper, ITripRepository tripRepository = null)
        {
            _route = route;
            _bus = bus;
            _mapper = mapper;
            _tripRepository = tripRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<TripViewModel>> GetRoute()
        {
            var test = _mapper.Map<IEnumerable<TripViewModel>>(await _tripRepository.GetAllTrips());


            return test.ToList();
        }
    }
}
