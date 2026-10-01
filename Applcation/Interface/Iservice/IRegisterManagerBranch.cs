using Applcation.Comman;
using Applcation.Feature.ManagerBranch.DTO;
using Domain.Entites;

namespace Applcation.Interface.Iservice
{
    public interface IRegisterManagerBranch
    {
        Task<ResultT<bool>> RegisterManagerBranches(RegisterManagerBranchDTO registerManagerBranchDTO, CancellationToken cancellationToken);
    }
}
