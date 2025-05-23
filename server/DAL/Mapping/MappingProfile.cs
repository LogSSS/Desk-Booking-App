using AutoMapper;
using Core.DTOs;
using DAL.Entities;

namespace DAL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Booking, BookingDTO>().ReverseMap();
        }
    }
}
