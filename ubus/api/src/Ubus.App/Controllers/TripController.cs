using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ubus.App.Commands.Trip;
using Ubus.App.ViewModels;
using Ubus.Business.Entities;
using Ubus.Business.Interfaces.Notifications;
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
        private readonly ITripDriverRepository _tripDriverRepository;
        private readonly IDriverRepository _driverRepository;
        public TripController(IMapper mapper,
                              ITripRepository tripRepository,
                              ITripService tripService,
                              INotifier notifier,
                              ITripDriverRepository tripDriverRepository, 
                              IDriverRepository driverRepository) : base(notifier)
        {
            _mapper = mapper;
            _tripRepository = tripRepository;
            _tripService = tripService;
            _tripDriverRepository = tripDriverRepository;
            _driverRepository = driverRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Add(CreateTripCommand tripCommand)
        {
            if (!ModelState.IsValid) return CustomResponse(tripCommand);

            var teste = _mapper.Map<Trip>(tripCommand);

            await _tripService.Add(teste);

            return CustomResponse(tripCommand);
        } 

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, TripViewModel tripViewModel)
        {
            if (tripViewModel.Id != id)
            {
                NotifierError("Ops, od Ids não conferem");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse();

            await _tripService.Update(_mapper.Map<Trip>(tripViewModel));

            return CustomResponse(tripViewModel);
        }

        [HttpPut("update-all-trips-finished")]
        public async Task<ActionResult> Update()
        {
            await _tripService.UpdateAllTripsFinished();

            return CustomResponse();
        }

        [HttpGet("{id:guid}")]
        public async Task<TripViewModel> GetById(Guid id)
        {
            return _mapper.Map<TripViewModel>(await _tripRepository.GetByIdWithRouteDriverBus(id));
        }

        [HttpGet]
        public async Task<IEnumerable<TripWithDriverNameViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<TripWithDriverNameViewModel>>(await _tripRepository.GetAllTrips());
        }

        #region trip-driver

        //[HttpGet("trip-driver")]
        //public async Task<IEnumerable<TripDriverViewModel>> GetAllTripsDrivers()
        //{
        //    return _mapper.Map<IEnumerable<TripDriverViewModel>>(await _tripDriverRepository.GetAllTripsDrivers());
        //}

        //[HttpGet("trip-driver/{id:guid}")]
        //public async Task<TripDriverViewModel> GetByIdTripDriver(Guid id)
        //{
        //    return _mapper.Map<TripDriverViewModel>(await _tripDriverRepository.GetById(id));
        //}

        //[HttpGet("trip-driver/driver/{id:guid}")]
        //public async Task<DriverViewModel> GetDriverByTripId(Guid id)
        //{
        //    var teste = _tripDriverRepository.GetByTripId(id);

        //    return _mapper.Map<DriverViewModel>(await _driverRepository.GetById(teste.DriverId));
        //}


        //[HttpPost("trip-driver")]
        //public async Task<ActionResult> AddDriver(CreateTripDriverCommand createTripDriver)
        //{
        //    if (!ModelState.IsValid) return CustomResponse(createTripDriver);

        //    await _tripDriverRepository.Add(_mapper.Map<TripDriver>(createTripDriver));

        //    return CustomResponse(createTripDriver);
        //}

        //[HttpPut("trip-driver/{id:guid}")]
        //public async Task<ActionResult> UpdateDriver(Guid id, TripDriverViewModel tripDriverViewModel)
        //{
        //    if (tripDriverViewModel.Id != id)
        //    {
        //        NotifierError("Ops, od Ids não conferem");
        //        return CustomResponse();
        //    }

        //    if (!ModelState.IsValid) return CustomResponse(tripDriverViewModel);

        //    await _tripDriverRepository.Update(_mapper.Map<TripDriver>(tripDriverViewModel));

        //    return CustomResponse(tripDriverViewModel);
        //}
        #endregion

    }
}
