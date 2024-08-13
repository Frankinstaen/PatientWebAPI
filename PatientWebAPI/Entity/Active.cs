namespace PatientWebAPI.Entity
{
    public class Active
    {
        public Guid Id { get; set; }
        public bool? IsActive { get; set; }
        public List<Patient>? Patients { get; set; }
    }
}
