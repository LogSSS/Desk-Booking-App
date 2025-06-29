using AutoMapper;
using Core.DTOs;
using DAL.Entities;

namespace DAL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Booking, BookingDTO>()
                .ForMember(dest => dest.Workspace, opt => opt.MapFrom(src => src.Workspace));

            CreateMap<BookingDTO, Booking>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Workspace, opt => opt.Ignore());

            CreateMap<Amenity, AmenityDTO>().ReverseMap();
            CreateMap<Capacity, CapacityDTO>().ReverseMap();
            CreateMap<RoomAvailability, RoomAvailabilityDTO>().ReverseMap();
            CreateMap<MyImage, MyImageDTO>().ReverseMap();

            CreateMap<Workspace, BaseWorkspaceDTO>()
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
                .ReverseMap();

            CreateMap<Workspace, WorkspaceDTO>()
                .ForMember(dest => dest.Booked, opt => opt.Ignore())
                .ForMember(dest => dest.Amenities, opt => opt.MapFrom(src => src.Amenities))
                .ForMember(
                    dest => dest.CapacityOptions,
                    opt => opt.MapFrom(src => src.CapacityOptions)
                )
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
                .ReverseMap();
        }
    }
}
