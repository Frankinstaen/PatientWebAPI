using PatientWebAPI.DTO.PersonDTO;
using PatientWebAPI.Entity;

namespace PatientWebAPI.DTO.NameDTO
{
    public class NameGetDTO
    {
        public Guid? Id { get; set; }
        public string? Use { get; set; }
        public string? Family { get; set; }
        public List<PersonGetDTO>? Given { get; set; }
    }
}
