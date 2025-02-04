using AutoMapper;

public class EntityToDtoMapping : Profile
{
    public EntityToDtoMapping()
    {
        CreateMap<Country, CountryDto>()
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name.common))
           .ForMember(dest => dest.Flag, opt => opt.MapFrom(src => src.flags.png));

        CreateMap<CountryDetails, CountryDetailsDto>()
          .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CommonName))
          .ForMember(dest => dest.Flag, opt => opt.MapFrom(src => src.FlagUrl))
          .ForMember(dest => dest.Capital, opt => opt.MapFrom(src => src.CapitalCity));

    }
}