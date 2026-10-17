using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applcation.Interface.IRepository
{
    public interface IManagerBranchRepository:IGenericRepository<ManagerBranch>
    {
        Task<ManagerBranch> GetManagerBranchByIdAsync(string id, CancellationToken cancellationToken);
    }
}
