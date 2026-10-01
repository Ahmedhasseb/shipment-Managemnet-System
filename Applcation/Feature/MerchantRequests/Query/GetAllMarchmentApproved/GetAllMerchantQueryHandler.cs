using Applcation.Comman;
using Applcation.Feature.MerchantRequest.DTO;
using Applcation.Interface.Iservice;
using MediatR;

namespace Applcation.Feature.MerchantRequests.Query.GetAllMarchmentApproved
{
    public class GetAllMerchantQueryHandler(IMarchmentRequestService _marchmentRequestService) : IRequestHandler<GetAllMerchantRequsetQuery, ResultT<List<GetAllMerchantReponse>>>
    {
        public async Task<ResultT<List<GetAllMerchantReponse>>> Handle(GetAllMerchantRequsetQuery request, CancellationToken cancellationToken)
        {
            var AllMarchment = await _marchmentRequestService.GetAllMerchmentApprove(cancellationToken);
            return AllMarchment;
        }
    }
}
