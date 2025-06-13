using API.Entities;
using AutoMapper;
using Core.DTOs;

namespace API.Mapping
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<UpsertBookingRequest, BookingDTO>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
