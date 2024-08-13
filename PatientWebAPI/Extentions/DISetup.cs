using AutoMapper;
using PatientWebAPI.Profiles;

namespace PatientWebAPI.Extentions
{
    public static class DISetup
    {
        public static void AddProfiles(this WebApplicationBuilder builder)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingPatientProfile());
                cfg.AddProfile(new MappingActiveProfile());
                cfg.AddProfile(new MappingGenderProfile());
                cfg.AddProfile(new MappingPersonProfile());
                cfg.AddProfile(new MappingNameProfile());
            });
            var mapper = config.CreateMapper();
            builder.Services.AddSingleton(mapper);
        }
    }
}
