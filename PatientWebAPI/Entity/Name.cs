namespace PatientWebAPI.Entity
{
    public class Name
    {
        public Guid Id { get; set; }
        public string? Use { get; set; }
        public string Family { get; set; }
        public List<Person>? Given { get; set; }
        public Guid? PatientId { get; set; }
        public Patient? Patient { get; set; }
    }
}
