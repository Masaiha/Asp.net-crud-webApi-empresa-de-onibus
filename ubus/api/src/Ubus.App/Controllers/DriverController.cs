using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ubus.App.ViewModels;
using Ubus.Business.Entities;
using Ubus.Business.Interfaces.Repositories;

namespace Ubus.App.Controllers
{
    [Route("drivers")]
    public class DriverController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IDriverRepository _driverRepository;

        public DriverController(IMapper mapper, IDriverRepository driverRepository)
        {
            _mapper = mapper;
            _driverRepository = driverRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Add(DriverViewModel driverViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _driverRepository.Add(_mapper.Map<Driver>(driverViewModel));

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, DriverViewModel driverViewModel)
        {
            if (id != driverViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            await _driverRepository.Update(_mapper.Map<Driver>(driverViewModel));

            return Ok();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DriverViewModel>> GetById(Guid id)
        {
            var driver = _driverRepository.GetById(id);

            if (driver == null) return NotFound();

            return Ok(driver);
        }

        [HttpGet]
        public async Task<IEnumerable<DriverViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<DriverViewModel>>(await _driverRepository.GetAll());
        }
    }
}
