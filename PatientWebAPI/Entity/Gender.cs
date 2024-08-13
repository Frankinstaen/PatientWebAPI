namespace PatientWebAPI.Entity
{
    public class Gender
    {
        public Guid Id { get; set; }
        public string? GenderName { get; set; }
        public List<Patient>? Patients { get; set; }

    }
}
