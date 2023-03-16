using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Pet, PetDTO>().ReverseMap();
            CreateMap<Owner, OwnerDTO>().ReverseMap();
            CreateMap<Accommodation, AccommodationDTO>().ReverseMap();

            CreateMap<PetDTO, Pet>()
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.OwnerDTO))
                .ForMember(dest => dest.AccommodationId, opt => opt.MapFrom(src => src.AccommodationNumber))
                .ForMember(dest => dest.HealthState, opt => opt.MapFrom(src => src.HealthState))
                .ReverseMap();
        }
    }
}