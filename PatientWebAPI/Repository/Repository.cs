using Microsoft.EntityFrameworkCore;
using PatientWebAPI.Data;

namespace PatientWebAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DataContext _context;
        protected DbSet<T> dbSet;
        protected readonly ILogger _logger;

        public Repository(DataContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            this.dbSet = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> All() 
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> Add(T entity)
        {
            try
            {
                var obj = await dbSet.AddAsync(entity);
                return obj.Entity;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error adding entity");
                return entity;
            }
        }


        public Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(Guid id)
        {
            try
            {
                return await dbSet.FindAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error getting entity with id {Id}", id);
                return null;
            }
        }

        public async Task<bool> Delete(T entity)
        {
            try
            {
                if (entity != null)
                {
                    dbSet.Remove(entity);
                    return true;
                }
                else
                {
                    _logger.LogWarning("Entity not found for deletion");
                    return false;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error deleting entity ");
                return false;
            }
        }
    }
}
