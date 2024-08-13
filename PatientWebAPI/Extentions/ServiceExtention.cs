using PatientWebAPI.Repository;

namespace PatientWebAPI.Extentions
{
    public static class ServiceExtention
    {
        public static void AddScopped(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
