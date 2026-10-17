using Applcation.Comman;
using Applcation.Feature.AuthApplacation.Login.LoginDTO;
using Applcation.Feature.AuthApplacation.RegisterUser.DTO;

namespace Applcation.Interface.Iservice
{
    public interface IAuthService
    {
        Task<Result> RegisterUser(RegisterUserDTO registerDTO);

        Task<Result<LoginResponseDTO>> signInApplaction(string Email, string Password);
    }
}
