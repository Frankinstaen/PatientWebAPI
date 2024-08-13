using AutoMapper;
using PatientWebAPI.DTO.PatientDTO;
using PatientWebAPI.Entity;

namespace PatientWebAPI.Profiles
{
    public class MappingPatientProfile : Profile
    {
        public MappingPatientProfile() {
            CreateMap<Patient, PatientDTO>()
                .ForMember(x => x.Id, c => c.MapFrom(x => x.Id))
                .ForMember(x => x.Name, c => c.MapFrom(x => x.Name))
                .ForMember(x => x.Gender, c => c.MapFrom(x => x.Gender.GenderName))
                .ForMember(x => x.BirthDate, c => c.MapFrom(x => x.BirthDate))
                .ForMember(x => x.Active, c => c.MapFrom(x => x.Active.IsActive));
            CreateMap<PatientAddDTO, Patient>()
                .ForMember(x => x.ActiveId, c => c.MapFrom(x => x.ActiveId))
                .ForMember(x => x.GenderId, c => c.MapFrom(x => x.GenderId))
                .ForMember(x => x.Name, c => c.MapFrom(x => x.Name))
                .ForMember(x => x.BirthDate, c => c.MapFrom(x => x.BirthDate));
        }
    }
}
