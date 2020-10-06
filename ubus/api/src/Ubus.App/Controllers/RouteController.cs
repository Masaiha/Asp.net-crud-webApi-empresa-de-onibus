using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ubus.App.ViewModels;
using Ubus.Business.Entities;
using Ubus.Business.Interfaces.Repositories;
using Ubus.Business.Interfaces.Services;

namespace Ubus.App.Controllers
{
    [Route("routes")]
    public class RouteController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IRouteRepository _routeRepository;
        private readonly IRouteService _routeService;

        public RouteController(IMapper mapper, IRouteRepository routeRepository, IRouteService routeService)
        {
            _mapper = mapper;
            _routeRepository = routeRepository;
            _routeService = routeService;
        }

        [HttpPost]
        public async Task<ActionResult> Add(RouteViewModel routeViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(new { Message = "Ops, Algo deu errado" });

            await _routeService.Add(_mapper.Map<Route>(routeViewModel));

            return Ok();
        } 

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, RouteViewModel routeViewModel)
        {
            if (routeViewModel.Id != id) return BadRequest(new { Message = "Ops, od Ids não conferem" });

            if(!ModelState.IsValid) return BadRequest(new { Message = "Ops, Algo deu errado" });

            await _routeService.Update(_mapper.Map<Route>(routeViewModel));

            return Ok(routeViewModel);
        }

        [HttpGet("{id:guid}")]
        public async Task<RouteViewModel> GetById(Guid id)
        {
            return _mapper.Map<RouteViewModel>(await _routeRepository.GetById(id));
        }

        [HttpGet]
        public async Task<IEnumerable<RouteViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<RouteViewModel>>(await _routeRepository.GetAll());
        }

    }
}
