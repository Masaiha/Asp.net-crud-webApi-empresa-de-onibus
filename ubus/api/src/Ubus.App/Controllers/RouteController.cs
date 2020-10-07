using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ubus.App.ViewModels;
using Ubus.Business.Entities;
using Ubus.Business.Interfaces.Notifications;
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

        public RouteController(IMapper mapper, 
                               IRouteRepository routeRepository, 
                               IRouteService routeService, 
                               INotifier notifier) : base(notifier)
        {
            _mapper = mapper;
            _routeRepository = routeRepository;
            _routeService = routeService;
        }

        [HttpPost]
        public async Task<ActionResult> Add(RouteViewModel routeViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse();

            await _routeService.Add(_mapper.Map<Route>(routeViewModel));

            return CustomResponse(routeViewModel);
        } 

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, RouteViewModel routeViewModel)
        {
            if (routeViewModel.Id != id)
            {
                NotifierError("Ops, od Ids não conferem");
                return CustomResponse();
            }

            if(!ModelState.IsValid) return CustomResponse(routeViewModel);

            await _routeService.Update(_mapper.Map<Route>(routeViewModel));
            return CustomResponse(routeViewModel);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RouteViewModel>> GetById(Guid id)
        {
            var route = _routeRepository.GetById(id);

            if (route == null) return NotFound();

            return _mapper.Map<RouteViewModel>(await _routeRepository.GetById(id));
        }

        [HttpGet]
        public async Task<IEnumerable<RouteViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<RouteViewModel>>(await _routeRepository.GetAll());
        }

    }
}
