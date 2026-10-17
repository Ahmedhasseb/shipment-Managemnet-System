using Applcation.Interface.IRepository;
using Domain.Entites;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.GenericRepository
{
    public class UniteOfWork :  IuniteOfWork
    {
        private readonly dbContext _dbContext;
        private IMerchantRequestRepository? _merchantRequestRepository;
        private IGenericRepository<Wallet>? _walletRepository;
       private IManagerBranchRepository? _ManagerBranchRepository;

        private IGenericRepository<Branch>? _BranchRepository;
        private IGenericRepository<Location>? _LocationRepository;
        private IGenericRepository<Merchant>? _MerchmentRepository;
        public UniteOfWork(dbContext dbContext) { _dbContext = dbContext; }


        public IMerchantRequestRepository MerchantRequestRepository => _merchantRequestRepository ??= new MerchantRequestRepository(_dbContext);



      

        public IGenericRepository<Wallet> walletRepository => _walletRepository ??= new Genericrepository<Wallet>(_dbContext);

        public IManagerBranchRepository ManagerBranchRepository => _ManagerBranchRepository ??= new ManagerBranchRepository (_dbContext);

        public IGenericRepository<Branch> BranchRepository => _BranchRepository ??= new Genericrepository<Branch>(_dbContext);

        public IGenericRepository<Location> LocationRepository => _LocationRepository ??= new Genericrepository<Location>(_dbContext);

        public IGenericRepository<Merchant> MerchmentRepository => _MerchmentRepository ??= new Genericrepository<Merchant>(_dbContext);

        IManagerBranchRepository IuniteOfWork.ManagerBranchRepository => throw new NotImplementedException();

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

