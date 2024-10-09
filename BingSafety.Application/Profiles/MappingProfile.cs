using AutoMapper;
using BingSafety.Application.Features.Contacts.Commands.ContactSingleNumber;
using BingSafety.Application.Features.EmergencyEvents.Commands.CreateEmergencyEvent;
using BingSafety.Application.Features.EmergencyEvents.Commands.DeleteEmergencyEvent;
using BingSafety.Application.Features.EmergencyEvents.Commands.UpdateEmergencyEvent;
using BingSafety.Application.Features.EmergencyEvents.Queries.GetEmergencyEventById;
using BingSafety.Application.Features.EmergencyEvents.Queries.GetEmergencyEventList;
using BingSafety.Application.Features.EventStatuses.Commands.CreateEventStatus;
using BingSafety.Application.Features.EventStatuses.Queries.GetEventStatusList;
using BingSafety.Domain.Models;

namespace BingSafety.Application.Profiles
{
    public class MappingProfile : Profile {
        public MappingProfile() { 
            CreateMap<EmergencyEvent, EmergencyEventListVm>().ReverseMap();
            CreateMap<EmergencyEvent, EmergencyEventByIdVm>().ReverseMap();
            CreateMap<EmergencyEvent, CreateEmergencyEventCommand>().ReverseMap();
            CreateMap<EmergencyEvent, UpdateEmergencyEventCommand>().ReverseMap();
            CreateMap<EmergencyEvent, DeleteEmergencyEventCommand>().ReverseMap();

            CreateMap<EventStatus, EventStatusListVm>().ReverseMap();
            CreateMap<EventStatus, CreateEventStatusCommand>().ReverseMap();

            CreateMap<Contact, ContactSingleNumberCommand>().ReverseMap();
        }
    }
}
