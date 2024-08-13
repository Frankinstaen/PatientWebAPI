using Microsoft.EntityFrameworkCore;
using PatientWebAPI.Data;
using PatientWebAPI.Entity;
using PatientWebAPI.Repository.PersonRepo;

namespace PatientWebAPI.Repository.NameRepo
{
    public class NameRepository : Repository<Name>, INameRepository
    {
        public NameRepository(DataContext context, ILogger logger) : base(context, logger) { }

        public async Task<Name> Add(Name entity)
        {
            var name = await dbSet.AddAsync(entity);
            return name.Entity;
        }

        public async Task<IEnumerable<Name>> All()
        {
            try
            {
                return await dbSet.Include(x => x.Given).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(PersonRepository));
                return new List<Name>();
            }
        }

        public async Task<bool> Delete(Name entity)
        {
            var result = dbSet.Remove(entity);
            return result.Entity != null;
        }

        public async Task<Name> GetById(Guid id)
        {
            return await dbSet.Include(x => x.Given)
                    .FirstAsync(x => x.Id == id);
        }

        public async Task<bool> Upsert(Name entity)
        {
            var result = dbSet.Update(entity);
            return result.Entity != null;
        }
    }
}
