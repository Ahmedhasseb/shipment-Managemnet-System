using Applcation.Comman;
using Applcation.Feature.MerchantRequest.DTO;
using MediatR;

namespace Applcation.Feature.MerchantRequests.Command.CreateRequestMerchmant
{
    public class MerchmantRequestCommand : IRequest<Results>
    {
        public RegisterMerchantRequest registerMerchantRequest { get; set; }
    }
}
