using Applcation.Feature.AuthApplacation.Login.Command;
using FluentValidation;

namespace Applcation.Feature.AuthApplacation.Login.Vailditor
{
    public class LoginVailditor : AbstractValidator<LoginCommand>
    {
        public LoginVailditor()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Pleas Enter Your Email");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is Requerid");
        }
    }
}
