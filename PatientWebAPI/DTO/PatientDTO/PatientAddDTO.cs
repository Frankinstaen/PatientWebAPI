using PatientWebAPI.DTO.NameDTO;

namespace PatientWebAPI.DTO.PatientDTO
{
    public class PatientAddDTO
    {
        public NameAddDTO? Name { get; set; }
        public Guid? GenderId { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid? ActiveId { get; set; }
    }
}
