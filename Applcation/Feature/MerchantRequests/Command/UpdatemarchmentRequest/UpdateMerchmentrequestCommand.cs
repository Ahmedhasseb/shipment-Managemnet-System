using Applcation.Comman;
using MediatR;

namespace Applcation.Feature.MerchantRequests.Command.UpdatemarchmentRequest
{
    public class UpdateMerchmentrequestCommand : IRequest<Results>
    {
        public int Id { get; set; }
    }
}
