using FluentValidation;

namespace Applcation.Feature.MerchantRequests.Command.UpdatemarchmentRequest
{
    public class UpdateMerchamentrequestVaildtior : AbstractValidator<UpdateMerchmentrequestCommand>
    {
        public UpdateMerchamentrequestVaildtior()
        {
            RuleFor(i => i.Id).NotEmpty().WithMessage("Id is requierd");
        }
    }
}
