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
    [Route("bus")]
    public class BusController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IBusRepository _busRepository;
        private readonly IBusService _busService;

        public BusController(IMapper mapper, 
                             IBusRepository busRepository, 
                             IBusService busService,
                             INotifier notifier) : base(notifier)
        {
            _mapper = mapper;
            _busRepository = busRepository;
            _busService = busService;
        }

        [HttpPost]
        public async Task<ActionResult> Add(BusViewModel busViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(busViewModel);

            await _busService.Add(_mapper.Map<Bus>(busViewModel));

            return CustomResponse(busViewModel);
        } 

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, BusViewModel busViewModel)
        {
            if (busViewModel.Id != id)
            {
                NotifierError("Ops, od Ids não conferem");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse();

            await _busService.Update(_mapper.Map<Bus>(busViewModel));

            return CustomResponse(busViewModel);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BusViewModel>> GetById(Guid id)
        {
            var bus = _busRepository.GetById(id);

            if (bus == null) return NotFound();

            return _mapper.Map<BusViewModel>(await _busRepository.GetById(id));
        }

        [HttpGet]
        public async Task<IEnumerable<BusViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<BusViewModel>>(await _busRepository.GetAll());
        }

    }
}
