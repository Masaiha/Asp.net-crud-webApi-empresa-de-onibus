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
    [Route("trips")]
    public class TripController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ITripRepository _tripRepository;
        private readonly ITripService _tripService;

        public TripController(IMapper mapper, ITripRepository tripRepository, ITripService tripService)
        {
            _mapper = mapper;
            _tripRepository = tripRepository;
            _tripService = tripService;
        }

        [HttpPost]
        public async Task<ActionResult> Add(TripViewModel tripViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(new { Message = "Ops, Algo deu errado" });

            await _tripService.Add(_mapper.Map<Trip>(tripViewModel));

            return Ok();
        } 

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, TripViewModel tripViewModel)
        {
            if (tripViewModel.Id != id) return BadRequest(new { Message = "Ops, od Ids não conferem" });

            if(!ModelState.IsValid) return BadRequest(new { Message = "Ops, Algo deu errado" });

            await _tripService.Update(_mapper.Map<Trip>(tripViewModel));

            return Ok(tripViewModel);
        }

        [HttpGet("{id:guid}")]
        public async Task<TripViewModel> GetById(Guid id)
        {
            return _mapper.Map<TripViewModel>(await _tripRepository.GetById(id));
        }

        [HttpGet]
        public async Task<IEnumerable<TripViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<TripViewModel>>(await _tripRepository.GetAll());
        }

    }
}
