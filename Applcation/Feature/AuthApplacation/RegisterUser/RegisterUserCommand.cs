using Applcation.Comman;
using Applcation.Feature.AuthApplacation.RegisterUser.DTO;
using MediatR;

namespace Applcation.Feature.AuthApplacation.RegisterUser
{
    public class RegisterUserCommand : IRequest<Result>
    {
        public RegisterUserDTO RegisterUser { get; set; }
    }
}
