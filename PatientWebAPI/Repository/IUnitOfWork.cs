using PatientWebAPI.Repository.ActiveRepo;
using PatientWebAPI.Repository.GenderRepo;
using PatientWebAPI.Repository.NameRepo;
using PatientWebAPI.Repository.PatientRepo;
using PatientWebAPI.Repository.PersonRepo;

namespace PatientWebAPI.Repository
{
    public interface IUnitOfWork
    {
        IPatientRepository PatientRepository { get; }
        IActiveRepository ActiveRepository { get; }
        IGenderRepository GenderRepository { get; }
        IPersonRepository PersonRepository { get; }
        INameRepository NameRepository { get; }
        Task CompleteAsync();
    }
}
