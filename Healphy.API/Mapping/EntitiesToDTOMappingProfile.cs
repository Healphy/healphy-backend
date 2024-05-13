using AutoMapper;
using Healphy.API.DTOs;
using Healphy.API.Models;

namespace Healphy.API.Mapping
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile() 
        {
            CreateMap<Doctor, DoctorDTO>().ReverseMap();
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
        }
    }
}
