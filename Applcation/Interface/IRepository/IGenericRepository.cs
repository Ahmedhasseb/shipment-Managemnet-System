namespace Applcation.Interface.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T item);
        void updateAsync(T item);
        void DeleteAsync(T item);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T> GetByid(int id);

    }
}
