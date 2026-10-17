namespace Applcation.Interface.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T item);
        void update(T item);
        void Delete(T item);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T> GetByidAsync(int id);

    }
}
