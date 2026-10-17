using Applcation.Comman;
using MediatR;

namespace Applcation.Feature.MerchantRequests.Command.UpdatemarchmentRequest
{
    public class UpdateMerchmentrequestCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
