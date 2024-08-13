using PatientWebAPI.Data;
using PatientWebAPI.Entity;
using PatientWebAPI.Repository.ActiveRepo;
using PatientWebAPI.Repository.GenderRepo;
using PatientWebAPI.Repository.NameRepo;
using PatientWebAPI.Repository.PatientRepo;
using PatientWebAPI.Repository.PersonRepo;

namespace PatientWebAPI.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context;
        private readonly ILogger _logger;

        public IPatientRepository PatientRepository { get; private set; }
        public IActiveRepository ActiveRepository { get; private set; }
        public IGenderRepository GenderRepository { get; private set; }
        public IPersonRepository PersonRepository { get; private set; }
        public INameRepository NameRepository { get; private set; }

        public UnitOfWork(DataContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            PatientRepository = new PatientRepository(_context, _logger);
            ActiveRepository = new ActiveRepository(_context, _logger);
            GenderRepository = new GenderRepository(_context, _logger);
            PersonRepository = new PersonRepository(_context, _logger);
            NameRepository = new NameRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
