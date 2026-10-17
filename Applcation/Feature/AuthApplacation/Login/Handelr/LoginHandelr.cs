using Applcation.Comman;
using Applcation.Feature.AuthApplacation.Login.Command;
using Applcation.Feature.AuthApplacation.Login.LoginDTO;
using Applcation.Interface.Iservice;
using MediatR;

namespace Applcation.Feature.AuthApplacation.Login.Handelr
{
    public class LoginHandelr(IAuthService authService) : IRequestHandler<LoginCommand, Result<LoginResponseDTO>>
    {
        public async Task<Result<LoginResponseDTO>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var LoginApp = await authService.signInApplaction(request.Email, request.Password);
            return LoginApp;

        }
    }
}
