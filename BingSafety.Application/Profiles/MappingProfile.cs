using AutoMapper;
using BingSafety.Application.Features.EmergencyEvents.Queries.GetEmergencyEventById;
using BingSafety.Application.Features.EmergencyEvents.Queries.GetEmergencyEventList;
using BingSafety.Application.Features.EventStatuses.Queries.GetEventStatusList;
using BingSafety.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSafety.Application.Profiles
{
    public class MappingProfile : Profile {
        public MappingProfile() { 
            CreateMap<EmergencyEvent, EmergencyEventListVm>().ReverseMap();
            CreateMap<EmergencyEvent, EmergencyEventByIdVm>().ReverseMap();
            CreateMap<EventStatus, EventStatusListVm>().ReverseMap();
        }
    }
}
