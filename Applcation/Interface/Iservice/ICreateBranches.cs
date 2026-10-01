using Applcation.Comman;
using Applcation.Feature.Branches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applcation.Interface.Iservice
{
    public interface ICreateBranchesService
    {
       public Task<ResultT<bool>> CreateBranch(BranchDTO branchDTO,CancellationToken cancellationToken);
    }
}
