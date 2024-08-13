namespace PatientWebAPI.Entity
{

    public class Patient
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }
        //public PatientGender? PatientGender { get; set; }
        public Guid? GenderId { get; set; }
        public Gender? Gender { get; set; }
        public DateTime BirthDate { get; set; }
        //public PatientActive? PatientActive { get; set; }
        public Guid? ActiveId { get; set; }
        public Active? Active { get; set; }
    }
}
