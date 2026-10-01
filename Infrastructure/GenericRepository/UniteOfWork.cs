using Applcation.Interface.IRepository;
using Domain.Entites;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.GenericRepository
{
    public class UniteOfWork : IuniteOfWork
    {
        private readonly dbContext _dbContext;
        private IMerchantRepository? _merchantRepository;
        private IGenericRepository<Wallet>? _walletRepository;
        private IGenericRepository<Merchant>? _MerchanrRepository;
        private IGenericRepository<ManagerBranch>? _ManagerBranchRepository;
        private IGenericRepository<Branch>? _BranchRepository;
        private IGenericRepository<Location>? _LocationRepository;
        public UniteOfWork(dbContext dbContext) { _dbContext = dbContext; }


        public IMerchantRepository MerchantRequestRepository => _merchantRepository ??= new MerchantRequestRepository(_dbContext);



        public IGenericRepository<Merchant> MerchanrRepository => _MerchanrRepository ??= new Genericrepository<Merchant>(_dbContext);

        public IGenericRepository<Wallet> walletRepository => _walletRepository ??= new Genericrepository<Wallet>(_dbContext);

        public IGenericRepository<ManagerBranch> ManagerBranchRepository => _ManagerBranchRepository ??= new Genericrepository<ManagerBranch>(_dbContext);

        public IGenericRepository<Branch> BranchRepository => _BranchRepository ??= new Genericrepository<Branch>(_dbContext);

        public IGenericRepository<Location> LocationRepository => _LocationRepository ??= new Genericrepository<Location>(_dbContext);

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);

        }
        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommiteAsync(CancellationToken cancellationToken = default)
        {
          await _dbContext.Database.CommitTransactionAsync(cancellationToken);
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.Database.RollbackTransactionAsync(cancellationToken);
        }
        }
    }

