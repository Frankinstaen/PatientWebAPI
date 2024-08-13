using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientWebAPI.Data;
using PatientWebAPI.Entity;

namespace PatientWebAPI.Repository.PatientRepo
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(DataContext context, ILogger logger) : base(context, logger) { }

        public async Task<Patient> Add(Patient entity)
        {
            var patient = await dbSet.AddAsync(entity);
            return patient.Entity;
        }

        public async Task<IEnumerable<Patient>> All()
        {
            try
            {
                return await dbSet.Include(x => x.Name)
                    .Include(x => x.Gender)
                    .Include(x => x.Active)
                    .Include(x => x.Name.Given).ToListAsync();
            } 
            catch (Exception ex) {
                _logger.LogError(ex, "{Repo} All function error", typeof(PatientRepository));
                return new List<Patient>();
            }
        }

        public async Task<bool> Delete(Patient entity)
        {
            var result = dbSet.Remove(entity);
            return result.Entity != null;
        }

        public async Task<Patient> GetById(Guid id)
        {
            return await dbSet.Include(x => x.Name)
                    .Include(x => x.Gender)
                    .Include(x => x.Active)
                    .Include(x => x.Name.Given)
                    .FirstAsync(x => x.Id == id);
        }

        public async Task<bool> Upsert(Patient entity)
        {
            var result = dbSet.Update(entity);
            return result.Entity != null;
        }
    }
}
