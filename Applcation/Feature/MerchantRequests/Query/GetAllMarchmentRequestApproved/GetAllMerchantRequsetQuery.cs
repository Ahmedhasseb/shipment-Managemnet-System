using Applcation.Comman;
using Applcation.Feature.MerchantRequest.DTO;
using MediatR;

namespace Applcation.Feature.MerchantRequests.Query.GetAllMarchmentApproved
{
    public record class GetAllMerchantRequsetQuery : IRequest<Result<List<GetAllMerchantReponse>>>
    {

    }
}
