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
    [Route("drivers")]
    public class DriverController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IDriverRepository _driverRepository;
        private readonly IDriverService _driverService;

        public DriverController(IMapper mapper, IDriverRepository driverRepository, IDriverService driverService)
        {
            _mapper = mapper;
            _driverRepository = driverRepository;
            _driverService = driverService;
        }

        [HttpPost]
        public async Task<ActionResult> Add(DriverViewModel driverViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _driverService.Add(_mapper.Map<Driver>(driverViewModel));

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, DriverViewModel driverViewModel)
        {
            if (id != driverViewModel.Id) return BadRequest(new { Message = "Ops, od Ids não conferem" });

            if (!ModelState.IsValid) return BadRequest();

            await _driverService.Update(_mapper.Map<Driver>(driverViewModel));

            return Ok();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DriverViewModel>> GetById(Guid id)
        {
            var driver = _mapper.Map<DriverViewModel>(await _driverRepository.GetById(id));

            if (driver == null) return NotFound();

            return driver;
        }

        [HttpGet]
        public async Task<IEnumerable<DriverViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<DriverViewModel>>(await _driverRepository.GetAll());
        }
    }
}
