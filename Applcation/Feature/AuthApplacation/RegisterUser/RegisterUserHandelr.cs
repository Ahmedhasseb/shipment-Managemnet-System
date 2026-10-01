using Applcation.Comman;
using Applcation.Interface.Iservice;
using MediatR;

namespace Applcation.Feature.AuthApplacation.RegisterUser
{
    public class RegisterUserHandelr(IAuthService _authService) : IRequestHandler<RegisterUserCommand, Results>
    {
        public async Task<Results> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var x = await _authService.RegisterUser(request.RegisterUser);
            return x;
        }
    }
}
