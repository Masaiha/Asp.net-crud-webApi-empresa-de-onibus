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
    [Route("additionals")]
    public class AdditionalController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IAdditionalRepository _additionalRepository;

        public AdditionalController(IMapper mapper, IAdditionalRepository additionalRepository)
        {
            _mapper = mapper;
            _additionalRepository = additionalRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Add(AdditionalViewModel additionalViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(new { Message = "Ops, Algo deu errado" });

            await _additionalRepository.Add(_mapper.Map<Additional>(additionalViewModel));

            return Ok();
        } 

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, AdditionalViewModel additionalViewModel)
        {
            if (additionalViewModel.Id != id) return BadRequest(new { Message = "Ops, od Ids não conferem" });

            if(!ModelState.IsValid) return BadRequest(new { Message = "Ops, Algo deu errado" });

            await _additionalRepository.Update(_mapper.Map<Additional>(additionalViewModel));

            return Ok(additionalViewModel);
        }

        [HttpGet("{id:guid}")]
        public async Task<AdditionalViewModel> GetById(Guid id)
        {
            return _mapper.Map<AdditionalViewModel>(await _additionalRepository.GetById(id));
        }

        [HttpGet]
        public async Task<IEnumerable<AdditionalViewModel>> GetAll(Guid id)
        {
            return _mapper.Map<IEnumerable<AdditionalViewModel>>(await _additionalRepository.GetAll());
        }

    }
}
