using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Ubus.Business.Entities;

namespace Ubus.App.ViewModels
{
    public class TripViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [ScaffoldColumn(false)]
        public Guid DriverId { get; set; }
        
        [ScaffoldColumn(false)]
        public Guid BusId { get; set; }

        [ScaffoldColumn(false)]
        public Guid RouteId { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public string Name { get; set; }

    //    [JsonIgnore]
        public DriverViewModel Driver { get; set; }

  //      [JsonIgnore]
        public RouteViewModel Route { get; set; }

//        [JsonIgnore]
        public BusViewModel Bus { get; set; }
        
        public bool IsFinished { get; set; }
    }
}
