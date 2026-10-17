using Applcation.Comman;
using Applcation.Feature.MerchantRequest.DTO;
using Applcation.Interface.Iservice;
using MediatR;

namespace Applcation.Feature.MerchantRequests.Query.GettAllMerchament
{
    public class GetAllMarchmentQueryHandelr(IMarchmentRequestService marchmentRequestService) : IRequestHandler<GetAllMarchmentQuery, Result<List<GetAllMerchantReponse>>>
    {
        public async Task<Result<List<GetAllMerchantReponse>>> Handle(GetAllMarchmentQuery request, CancellationToken cancellationToken)
        {
            var result = await marchmentRequestService.GettAllMarchment(cancellationToken);
            return result;
        }
    }
}
