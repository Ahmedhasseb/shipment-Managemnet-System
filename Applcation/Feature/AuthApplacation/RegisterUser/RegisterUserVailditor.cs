using FluentValidation;
namespace Applcation.Feature.AuthApplacation.RegisterUser
{
    public class RegisterUserVailditor : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserVailditor()
        {
            RuleFor(x => x.RegisterUser.FirstName).NotEmpty().WithMessage("First Name is required.");
            RuleFor(x => x.RegisterUser.LastName).NotEmpty().WithMessage("Last Name is required.");
            RuleFor(x => x.RegisterUser.UserName).NotEmpty().WithMessage("Username is required.");

            RuleFor(x => x.RegisterUser.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.RegisterUser.Password).NotEmpty().WithMessage("Password is required.").MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
            RuleFor(x => x.RegisterUser.DateOfBirth).NotEmpty().WithMessage("Date of Birth is required.").LessThan(DateTime.Now).WithMessage("Date of Birth must be in the past.");

        }
    }
}
