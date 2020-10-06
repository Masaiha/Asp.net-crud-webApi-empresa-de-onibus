using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Ubus.App.ViewModels;
using Ubus.Business.Entities;
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

        public BusController(IMapper mapper, IBusRepository busRepository, IBusService busService)
        {
            _mapper = mapper;
            _busRepository = busRepository;
            _busService = busService;
        }

        [HttpPost]
        public async Task<ActionResult> Add(BusViewModel busViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(new { Message = "Ops, Algo deu errado" });

            await _busService.Add(_mapper.Map<Bus>(busViewModel));

            return Ok();
        } 

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, BusViewModel busViewModel)
        {
            if (busViewModel.Id != id) return BadRequest(new { Message = "Ops, od Ids não conferem" });

            if(!ModelState.IsValid) return BadRequest(new { Message = "Ops, Algo deu errado" });

            await _busService.Update(_mapper.Map<Bus>(busViewModel));

            return Ok(busViewModel);
        }

        [HttpGet("{id:guid}")]
        public async Task<BusViewModel> GetById(Guid id)
        {
            return _mapper.Map<BusViewModel>(await _busRepository.GetById(id));
        }

    }
}
