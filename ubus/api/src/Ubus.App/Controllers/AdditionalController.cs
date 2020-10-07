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
    [Route("additionals")]
    public class AdditionalController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IAdditionalRepository _additionalRepository;
        private readonly IAdditionalService _additionalService;

        public AdditionalController(IMapper mapper, 
                                    IAdditionalRepository additionalRepository, 
                                    IAdditionalService additionalService,
                                    INotifier notifier) : base(notifier)
        {
            _mapper = mapper;
            _additionalRepository = additionalRepository;
            _additionalService = additionalService;
        }

        [HttpPost]
        public async Task<ActionResult> Add(AdditionalViewModel additionalViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(additionalViewModel);

            await _additionalService.Add(_mapper.Map<Additional>(additionalViewModel));

            return CustomResponse(additionalViewModel);
        } 

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, AdditionalViewModel additionalViewModel)
        {
            if (additionalViewModel.Id != id)
            {
                NotifierError("Ops, od Ids não conferem");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(additionalViewModel);

            await _additionalService.Update(_mapper.Map<Additional>(additionalViewModel));

            return CustomResponse(additionalViewModel);
        }

        [HttpGet("{id:guid}")]
        public async Task<AdditionalViewModel> GetById(Guid id)
        {
            return _mapper.Map<AdditionalViewModel>(await _additionalRepository.GetById(id));
        }

        [HttpGet]
        public async Task<IEnumerable<AdditionalViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<AdditionalViewModel>>(await _additionalRepository.GetAll());
        }

    }
}
