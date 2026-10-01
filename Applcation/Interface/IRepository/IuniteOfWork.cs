using Domain.Entites;

namespace Applcation.Interface.IRepository
{
    public interface IuniteOfWork : IDisposable
    {

        IMerchantRepository MerchantRequestRepository { get; }
        IGenericRepository<Merchant> MerchanrRepository { get; }
        IGenericRepository<Wallet> walletRepository { get; }
        IGenericRepository<ManagerBranch> ManagerBranchRepository { get; }
        IGenericRepository<Branch> BranchRepository { get; }
        IGenericRepository<Location> LocationRepository {  get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommiteAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);  
    }
}
