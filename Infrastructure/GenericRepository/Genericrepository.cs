using Applcation.Interface.IRepository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.GenericRepository
{
    public class Genericrepository<T> : IGenericRepository<T> where T : class
    {
        private readonly dbContext _dbContext;

        public Genericrepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(T item) => await _dbContext.Set<T>().AddAsync(item);




        public void Delete(T item) => _dbContext.Set<T>().Remove(item);




        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken) => await _dbContext.Set<T>().ToListAsync(cancellationToken);


        public async Task<T> GetByidAsync(int id) => await _dbContext.Set<T>().FindAsync(id);


        public void update(T item) => _dbContext.Set<T>().Update(item);

    }
}
