using AutoMapper;
using PatientWebAPI.DTO.NameDTO;
using PatientWebAPI.Entity;

namespace PatientWebAPI.Profiles
{
    public class MappingNameProfile : Profile
    {
        public MappingNameProfile() {
            CreateMap<Name, NameGetDTO>()
                .ForMember(x => x.Id, c => c.MapFrom(x => x.Id))
                .ForMember(x => x.Use, c => c.MapFrom(x => x.Use))
                .ForMember(x => x.Given, c => c.MapFrom(x => x.Given))
                .ForMember(x => x.Family, c => c.MapFrom(x => x.Family));
            CreateMap<NameAddDTO, Name>()
                .ForMember(x => x.Use, c => c.MapFrom(x => x.Use))
                .ForMember(x => x.Given, c => c.MapFrom(x => x.Given))
                .ForMember(x => x.Family, c => c.MapFrom(x => x.Family));
            CreateMap<Name, NameAddDTO>()
                .ForMember(x => x.Use, c => c.MapFrom(x => x.Use))
                .ForMember(x => x.Given, c => c.MapFrom(x => x.Given))
                .ForMember(x => x.Family, c => c.MapFrom(x => x.Family));
        }
    }
}
