using Applcation.Comman;
using Applcation.Feature.MerchantRequest.DTO;

namespace Applcation.Interface.Iservice
{
    public interface IMarchmentRequestService
    {
        Task<ResultT<string>> AcceptEmailMerchant(int id, CancellationToken cancellationToken);
        Task<Results> CreateMerchmentRquest(RegisterMerchantRequest registerMerchantRequest, CancellationToken cancellationToken);
        Task<ResultT<List<GetAllMerchantReponse>>> GetAllMerchmentApprove(CancellationToken cancellationToken);
        Task<ResultT<List<GetAllMerchantReponse>>> GettAllMarchment(CancellationToken cancellationToken);

        Task<ResultT<List<GetAllMerchantReponse>>> GetAllMerchamntRequestByBranch(string UserId, CancellationToken cancellationToken);

    }
}
