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
            CreateMap<Booking, BookingDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.Status))
                .ForMember(
                    dest => dest.WorkspaceType,
                    opt => opt.MapFrom(src => (int)src.WorkspaceType)
                )
                .ReverseMap()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (Status)src.Status))
                .ForMember(
                    dest => dest.WorkspaceType,
                    opt => opt.MapFrom(src => (Workspace)src.WorkspaceType)
                );
            CreateMap<BookingsList, BookingsListDTO>().ReverseMap();
        }
    }
}
