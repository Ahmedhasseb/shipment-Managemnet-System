using Applcation.Comman;
using Applcation.Feature.AuthApplacation.Login.LoginDTO;
using Applcation.Feature.AuthApplacation.RegisterUser.DTO;

namespace Applcation.Interface.Iservice
{
    public interface IAuthService
    {
        Task<Results> RegisterUser(RegisterUserDTO registerDTO);

        Task<ResultT<LoginResponseDTO>> signInApplaction(string Email, string Password);
    }
}
