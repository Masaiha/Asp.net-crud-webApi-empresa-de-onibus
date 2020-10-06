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
    public class MiniBarController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IMiniBarRepository _miniBarRepository;

        public MiniBarController(IMapper mapper, IMiniBarRepository miniBarRepository)
        {
            _mapper = mapper;
            _miniBarRepository = miniBarRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Add(MiniBarViewModel miniBar)
        {
            if (!ModelState.IsValid) return BadRequest(new { Message = "Ops, Algo deu errado" });

            await _miniBarRepository.Add(_mapper.Map<MiniBar>(miniBar));

            return Ok();
        } 

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, MiniBarViewModel miniBar)
        {
            if (miniBar.Id != id) return BadRequest(new { Message = "Ops, od Ids não conferem" });

            if(!ModelState.IsValid) return BadRequest(new { Message = "Ops, Algo deu errado" });

            await _miniBarRepository.Update(_mapper.Map<MiniBar>(miniBar));

            return Ok(miniBar);
        }

        [HttpGet("{id:guid}")]
        public async Task<MiniBarViewModel> GetMinibarId(Guid id)
        {
            return _mapper.Map<MiniBarViewModel>(await _miniBarRepository.GetById(id));
        }

    }
}
