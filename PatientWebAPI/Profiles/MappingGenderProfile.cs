using AutoMapper;
using PatientWebAPI.DTO.GenderDTO;
using PatientWebAPI.DTO.PatientDTO;
using PatientWebAPI.Entity;

namespace PatientWebAPI.Profiles
{
    public class MappingGenderProfile : Profile
    {
        public MappingGenderProfile()
        {
            CreateMap<Gender, GenderGetDTO>()
                .ForMember(x => x.Id, c => c.MapFrom(x => x.Id))
                .ForMember(x => x.GenderName, c => c.MapFrom(x => x.GenderName));
        }
    }
}
