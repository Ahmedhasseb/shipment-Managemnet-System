using Applcation.Comman;
using Applcation.Feature.MerchantRequest.DTO;
using MediatR;

namespace Applcation.Feature.MerchantRequests.Query.GettAllMerchament
{
    public sealed class GetAllMarchmentQuery : IRequest<Result<List<GetAllMerchantReponse>>>
    {
    }
}
