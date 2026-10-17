using Applcation.Comman;
using Applcation.Interface.Iservice;
using MediatR;

namespace Applcation.Feature.AuthApplacation.RegisterUser
{
    public class RegisterUserHandelr(IAuthService _authService) : IRequestHandler<RegisterUserCommand, Result>
    {
        public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var x = await _authService.RegisterUser(request.RegisterUser);
            return x;
        }
    }
}
