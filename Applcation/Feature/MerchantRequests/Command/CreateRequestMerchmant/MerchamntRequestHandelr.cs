using Applcation.Comman;
using Applcation.Interface.Iservice;
using MediatR;

namespace Applcation.Feature.MerchantRequests.Command.CreateRequestMerchmant
{
    public class MerchamntRequestHandelr(IMarchmentRequestService _marchmentRequestService) : IRequestHandler<MerchmantRequestCommand, Results>
    {
        public async Task<Results> Handle(MerchmantRequestCommand request, CancellationToken cancellationToken)
        {
            var CreateRequest = await _marchmentRequestService.CreateMerchmentRquest(request.registerMerchantRequest, cancellationToken);
            return CreateRequest;
        }
    }
}

