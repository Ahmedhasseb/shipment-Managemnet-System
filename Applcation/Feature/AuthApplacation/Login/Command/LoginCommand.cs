using Applcation.Comman;
using Applcation.Feature.AuthApplacation.Login.LoginDTO;
using MediatR;

namespace Applcation.Feature.AuthApplacation.Login.Command
{
    public class LoginCommand : IRequest<ResultT<LoginResponseDTO>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
