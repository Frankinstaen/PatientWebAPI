using AutoMapper;
using PatientWebAPI.DTO.ActiveDTO;
using PatientWebAPI.DTO.PatientDTO;
using PatientWebAPI.Entity;

namespace PatientWebAPI.Profiles
{
    public class MappingActiveProfile : Profile
    {
        public MappingActiveProfile()
        {
            CreateMap<Active, ActiveGetDTO>()
                .ForMember(x => x.Id, c => c.MapFrom(x => x.Id))
                .ForMember(x => x.IsActive, c => c.MapFrom(x => x.IsActive));
        }
    }
}
