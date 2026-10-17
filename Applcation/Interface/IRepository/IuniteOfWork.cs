using Domain.Entites;

namespace Applcation.Interface.IRepository
{
    public interface IuniteOfWork : IDisposable
    {

        IMerchantRequestRepository MerchantRequestRepository { get; }
        IManagerBranchRepository ManagerBranchRepository { get; }
        IGenericRepository<Wallet> walletRepository { get; }
        
        IGenericRepository<Branch> BranchRepository { get; }
        IGenericRepository<Location> LocationRepository {  get; }
        IGenericRepository<Merchant> MerchmentRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommiteAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);  
    }
}
