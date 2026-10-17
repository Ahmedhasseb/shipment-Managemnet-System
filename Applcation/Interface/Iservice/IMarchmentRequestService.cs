using Applcation.Comman;
using Applcation.Feature.MerchantRequest.DTO;

namespace Applcation.Interface.Iservice
{
    public interface IMarchmentRequestService
    {
        Task<Result<string>> AcceptEmailMerchant(int id, CancellationToken cancellationToken);
        Task<Result> CreateMerchmentRquest(RegisterMerchantRequest registerMerchantRequest, CancellationToken cancellationToken);
        Task<Result<List<GetAllMerchantReponse>>> GetAllMerchmentApprove(CancellationToken cancellationToken);
        Task<Result<List<GetAllMerchantReponse>>> GettAllMarchment(CancellationToken cancellationToken);

        Task<Result<List<GetAllMerchantReponse>>> GetAllMerchamntRequestByBranch(string UserId, CancellationToken cancellationToken);

    }
}
