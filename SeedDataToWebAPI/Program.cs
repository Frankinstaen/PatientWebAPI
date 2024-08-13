using System.Net.Http.Json;

class Program
{
    static HttpClient httpClient = new HttpClient();
    static async Task Main()
    {
        var actives = await GetActivesAsync();
        var genders = await GetGendersAsync();
        if (actives != null && genders != null && actives.Count > 0 && genders.Count > 0)
        {
            var rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                var randomActive = rnd.Next(0, actives.Count);
                var randomGender = rnd.Next(0, genders.Count);
                var patient = new PatientAddDTO
                {
                    Name = new NameAddDTO
                    {
                        Use = "official",
                        Family = "Иванов" + i.ToString()
                    },
                    GenderId = genders[randomGender].Id,
                    BirthDate = Date(new DateTime(1970, 12, 31), new DateTime(2023, 12, 31)),
                    ActiveId = actives[randomActive].Id,
                };
                using var response = await httpClient.PostAsJsonAsync("http://web_api_application:80/api/patients/", patient);
            }
        }
    }

    private static async Task<List<ActiveGetDTO>?> GetActivesAsync()
    {
        List<ActiveGetDTO>? actives = await httpClient.GetFromJsonAsync<List<ActiveGetDTO>>("http://web_api_application:80/api/actives");
        return actives;
    }

    private static async Task<List<GenderGetDTO>?> GetGendersAsync()
    {
        List<GenderGetDTO>? genders = await httpClient.GetFromJsonAsync<List<GenderGetDTO>>("http://web_api_application:80/api/genders");
        return genders;
    }

    private static DateTime Date(DateTime startDate, DateTime endDate)
    {
        var rnd = new Random();
        var randomYear = rnd.Next(startDate.Year, endDate.Year);
        var randomMonth = rnd.Next(1, 12);
        var randomDay = rnd.Next(1, DateTime.DaysInMonth(randomYear, randomMonth));

        if (randomYear == startDate.Year)
        {
            randomMonth = rnd.Next(startDate.Month, 12);

            if (randomMonth == startDate.Month)
                randomDay = rnd.Next(startDate.Day, DateTime.DaysInMonth(randomYear, randomMonth));
        }

        if (randomYear == endDate.Year)
        {
            randomMonth = rnd.Next(1, endDate.Month);

            if (randomMonth == endDate.Month)
                randomDay = rnd.Next(1, endDate.Day);
        }

        var randomDate = new DateTime(randomYear, randomMonth, randomDay);

        return randomDate;
    }
}
public class PatientAddDTO
{
    public NameAddDTO? Name { get; set; }
    public Guid? GenderId { get; set; }
    public DateTime BirthDate { get; set; }
    public Guid? ActiveId { get; set; }
}
public class NameAddDTO
{
    public string? Use { get; set; }
    public string Family { get; set; }
    public List<PersonAddDTO>? Given { get; set; }
}
public class PersonAddDTO
{
    public string? FirstName { get; set; }
    public string? Patronymic { get; set; }
}
public class ActiveGetDTO
{
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
}
public class GenderGetDTO
{
    public Guid Id { get; set; }
    public string GenderName { get; set; }
}
