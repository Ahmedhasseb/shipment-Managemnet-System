using Applcation.Comman;

namespace Applcation.Interface.Iservice
{
    public interface IRestPassword
    {
        Task<ResultT<bool>> RestartPaswword(string email, string newPassword);
    }
}
