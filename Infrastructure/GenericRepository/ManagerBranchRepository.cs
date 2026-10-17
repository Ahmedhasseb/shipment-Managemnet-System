using Applcation.Interface.IRepository;
using Domain.Entites;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.GenericRepository
{
    public class ManagerBranchRepository : Genericrepository<ManagerBranch>, IManagerBranchRepository
    {
        private readonly dbContext _dbContext;

        public ManagerBranchRepository(dbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async  Task<ManagerBranch> GetManagerBranchByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await _dbContext.ManagerBranches.AsNoTracking().FirstOrDefaultAsync(mb => mb.UserId == id, cancellationToken);
        }
    }
}
