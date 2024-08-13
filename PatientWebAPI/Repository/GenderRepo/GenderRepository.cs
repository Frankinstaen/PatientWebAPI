using Microsoft.EntityFrameworkCore;
using PatientWebAPI.Data;
using PatientWebAPI.Entity;
using PatientWebAPI.Repository.ActiveRepo;

namespace PatientWebAPI.Repository.GenderRepo
{
    public class GenderRepository : Repository<Gender>, IGenderRepository
    {
        public GenderRepository(DataContext context, ILogger logger) : base(context, logger) { }

        public async Task<Gender> Add(Gender entity)
        {
            var result = await dbSet.AddAsync(entity);
            return result.Entity;
        }
        public async Task<IEnumerable<Gender>> All()
        {
            try
            {
                return await dbSet.Include(x => x.Patients).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(GenderRepository));
                return new List<Gender>();
            }
        }

        public async Task<bool> Delete(Gender entity)
        {
            var result = dbSet.Remove(entity);
            return result.Entity != null;
        }

        public async Task<Gender> GetById(Guid id)
        {
            return await dbSet.Include(x => x.Patients).FirstAsync(x => x.Id == id);
        }

        public async Task<bool> Upsert(Gender entity)
        {
            var result = dbSet.Update(entity);
            return result.Entity != null;
        }
    }
}
