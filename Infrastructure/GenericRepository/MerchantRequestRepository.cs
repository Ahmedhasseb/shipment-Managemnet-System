using Applcation.Interface.IRepository;
using Domain.Entites;
using Domain.Enums;
using Infrastructure.Data;
using Infrastructure.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class MerchantRequestRepository : Genericrepository<MerchantRequests>, IMerchantRepository
    {
        private readonly dbContext _dbContext;




        public MerchantRequestRepository(dbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;


        }



        public async Task<List<MerchantRequests>> GetAllMerchantsAproved(CancellationToken cancellationToken)
        {

            var GetAllMarchmentApprove = await _dbContext.MerchantRequests.Where(i => i.registerionRequest == RegisterionRequestMarchment.Approve).ToListAsync(cancellationToken);
            return GetAllMarchmentApprove;



        }

        public async Task<List<MerchantRequests>> GetAllMerchamntRequestByBranch(int branchId, CancellationToken cancellationToken)
        {
            return await _dbContext.MerchantRequests.Where(m => m.BranchId== branchId ).ToListAsync(cancellationToken);
        }

    }
}
