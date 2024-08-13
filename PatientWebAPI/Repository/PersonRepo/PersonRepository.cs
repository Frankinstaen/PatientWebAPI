using Microsoft.EntityFrameworkCore;
using PatientWebAPI.Data;
using PatientWebAPI.Entity;
using PatientWebAPI.Repository.PatientRepo;

namespace PatientWebAPI.Repository.PersonRepo
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DataContext context, ILogger logger) : base(context, logger) { }

        public async Task<Person> Add(Person entity)
        {
            var person = await dbSet.AddAsync(entity);
            return person.Entity;
        }

        public async Task<IEnumerable<Person>> All()
        {
            try
            {
                return await dbSet.Include(x => x.Name)
                    .Include(x => x.Name.Given).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(PersonRepository));
                return new List<Person>();
            }
        }

        public async Task<bool> Delete(Person entity)
        {
            var result = dbSet.Remove(entity);
            return result.Entity != null;
        }

        public async Task<Person> GetById(Guid id)
        {
            return await dbSet.Include(x => x.Name)
                    .Include(x => x.Name.Given)
                    .FirstAsync(x => x.Id == id);
        }

        public async Task<bool> Upsert(Person entity)
        {
            var result = dbSet.Update(entity);
            return result.Entity != null;
        }
    }
}
