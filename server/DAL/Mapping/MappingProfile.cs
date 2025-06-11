using AutoMapper;
using Core.DTOs;
using DAL.Entities;
using Shared.Enums;

namespace DAL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Booking, BookingDTO>();

            CreateMap<Amenity, AmenityDTO>();
            CreateMap<Capacity, CapacityDTO>();
            CreateMap<RoomAvailability, RoomAvailabilityDTO>();

            CreateMap<Workspace, WorkspaceDTO>()
                .ForMember(dest => dest.Amenities, opt => opt.MapFrom(src => src.Amenities))
                .ForMember(
                    dest => dest.CapacityOptions,
                    opt => opt.MapFrom(src => src.CapacityOptions)
                )
                .ForMember(dest => dest.Booked, opt => opt.MapFrom(src => src.Booked));
        }
    }
}
