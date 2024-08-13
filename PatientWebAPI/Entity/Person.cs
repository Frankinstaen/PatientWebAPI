namespace PatientWebAPI.Entity
{
    public class Person
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? Patronymic { get; set; }
        public Guid NameId { get; set; }
        public Name Name { get; set; }
    }
}
