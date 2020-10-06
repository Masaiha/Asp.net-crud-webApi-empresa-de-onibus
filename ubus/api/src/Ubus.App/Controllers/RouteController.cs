using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Ubus.App.ViewModels;
using Ubus.Business.Entities;
using Ubus.Business.Interfaces.Repositories;

namespace Ubus.App.Controllers
{
    [Route("minibar")]
    public class RouteController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IRouteRepository _routeRepository;

        public RouteController(IMapper mapper, IRouteRepository routeRepository)
        {
            _mapper = mapper;
            _routeRepository = routeRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Add(RouteViewModel routeViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(new { Message = "Ops, Algo deu errado" });

            await _routeRepository.Add(_mapper.Map<Route>(routeViewModel));

            return Ok();
        } 

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, RouteViewModel routeViewModel)
        {
            if (routeViewModel.Id != id) return BadRequest(new { Message = "Ops, od Ids não conferem" });

            if(!ModelState.IsValid) return BadRequest(new { Message = "Ops, Algo deu errado" });

            await _routeRepository.Update(_mapper.Map<Route>(routeViewModel));

            return Ok(routeViewModel);
        }

        [HttpGet("{id:guid}")]
        public async Task<RouteViewModel> GetById(Guid id)
        {
            return _mapper.Map<RouteViewModel>(await _routeRepository.GetById(id));
        }

    }
}
