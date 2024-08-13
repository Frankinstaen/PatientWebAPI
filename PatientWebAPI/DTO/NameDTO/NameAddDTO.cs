using PatientWebAPI.DTO.PersonDTO.PersonDTO;

namespace PatientWebAPI.DTO.NameDTO
{
    public class NameAddDTO
    {
        public string? Use { get; set; }
        public string Family { get; set; }
        public List<PersonAddDTO>? Given { get; set; }
    }
}
