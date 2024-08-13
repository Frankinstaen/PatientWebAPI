using PatientWebAPI.DTO.NameDTO;
using PatientWebAPI.Entity;

namespace PatientWebAPI.DTO.PatientDTO
{
    public class PatientDTO
    {
        public Guid Id { get; set; }
        public NameGetDTO? Name { get; set; }
        public string? Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public bool? Active { get; set; }
    }
}
