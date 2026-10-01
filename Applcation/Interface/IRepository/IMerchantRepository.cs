using Domain.Entites;
namespace Applcation.Interface.IRepository
{
    public interface IMerchantRepository : IGenericRepository<MerchantRequests>
    {
        Task<List<MerchantRequests>> GetAllMerchantsAproved(CancellationToken cancellationToken);

        Task<List<MerchantRequests>> GetAllMerchamntRequestByBranch( int branchId, CancellationToken cancellationToken);



    }
}
