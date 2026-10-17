using Applcation.Comman;
using Applcation.Interface.Iservice;
using MediatR;

namespace Applcation.Feature.MerchantRequests.Command.UpdatemarchmentRequest
{
    public class UpdateMerchamentRequestHandelr(IMarchmentRequestService _marchmentRequestService) : IRequestHandler<UpdateMerchmentrequestCommand, Result>
    {
        public async Task<Result> Handle(UpdateMerchmentrequestCommand request, CancellationToken cancellationToken)
        {
            var AcceptRequest = await _marchmentRequestService.AcceptEmailMerchant(request.Id, cancellationToken);
            return AcceptRequest;
        }
    }
}
