using FluentValidation;

namespace Applcation.Feature.MerchantRequests.Command.CreateRequestMerchmant
{
    public class MerchamentRequestVailditor : AbstractValidator<MerchmantRequestCommand>
    {

        public MerchamentRequestVailditor()
        {
            RuleFor(i => i.registerMerchantRequest.FName).NotEmpty().WithMessage("Please Enter the First Name is Requierd");
            RuleFor(i => i.registerMerchantRequest.LName).NotEmpty().WithMessage("Please Enter the Last Name is Requierd");
            RuleFor(i => i.registerMerchantRequest.Email).NotEmpty().WithMessage("Please Enter the Email is Requierd");
            RuleFor(i => i.registerMerchantRequest.CompanyName).NotEmpty().WithMessage("Please Enter the CompanyName is Requierd");
            RuleFor(i => i.registerMerchantRequest.PhoneMerchant).NotEmpty().WithMessage("Please Enter the Phone Merchament is Requierd");
            RuleFor(i => i.registerMerchantRequest.Address).NotEmpty().WithMessage("Please Enter the Address is Requierd");

        }
    }
}
