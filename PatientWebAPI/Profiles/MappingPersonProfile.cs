using AutoMapper;
using PatientWebAPI.DTO.PersonDTO;
using PatientWebAPI.DTO.PersonDTO.PersonDTO;
using PatientWebAPI.Entity;

namespace PatientWebAPI.Profiles
{
    public class MappingPersonProfile : Profile
    {
        public MappingPersonProfile() {
            CreateMap<Person, PersonGetDTO>()
                .ForMember(x => x.Id, c => c.MapFrom(x => x.Id))
                .ForMember(x => x.FirstName, c => c.MapFrom(x => x.FirstName))
                .ForMember(x => x.Patronymic, c => c.MapFrom(x => x.Patronymic));
            CreateMap<PersonGetDTO, Person>()
                .ForMember(x => x.Id, c => c.MapFrom(x => x.Id))
                .ForMember(x => x.FirstName, c => c.MapFrom(x => x.FirstName))
                .ForMember(x => x.Patronymic, c => c.MapFrom(x => x.Patronymic));
            CreateMap<Person, PersonAddDTO>()
                .ForMember(x => x.FirstName, c => c.MapFrom(x => x.FirstName))
                .ForMember(x => x.Patronymic, c => c.MapFrom(x => x.Patronymic));
            CreateMap<PersonAddDTO, Person>()
                .ForMember(x => x.FirstName, c => c.MapFrom(x => x.FirstName))
                .ForMember(x => x.Patronymic, c => c.MapFrom(x => x.Patronymic));
        }
    }
}
