namespace PatientWebAPI.Repository
{
    public interface IRepository<T> where T : class 
    {
        Task<IEnumerable<T>> All(); 
        Task<T> GetById(Guid id);

        Task<T> Add(T entity);

        Task<bool> Delete(T entity);

        Task<bool> Upsert(T entity);
    }
}
