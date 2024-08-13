using Microsoft.EntityFrameworkCore;
using PatientWebAPI.Data;
using PatientWebAPI.Entity;

namespace PatientWebAPI.Repository.ActiveRepo
{
    public class ActiveRepository : Repository<Active>, IActiveRepository
    {
        public ActiveRepository(DataContext context, ILogger logger) : base(context, logger) { }

        public async Task<Active> Add(Active entity)
        {
            var result = await dbSet.AddAsync(entity);
            return result.Entity;
        }
        public async Task<IEnumerable<Active>> All()
        {
            try
            {
                return await dbSet.Include(x => x.Patients).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(ActiveRepository));
                return new List<Active>();
            }
        }

        public async Task<bool> Delete(Active entity)
        {
            var result = dbSet.Remove(entity);
            return result.Entity != null;
        }

        public async Task<Active> GetById(Guid id)
        {
            return await dbSet.Include(x => x.Patients).FirstAsync(x => x.Id == id);
        }

        public async Task<bool> Upsert(Active entity)
        {
            var result = dbSet.Update(entity);
            return result.Entity != null;
        }
    }
}
