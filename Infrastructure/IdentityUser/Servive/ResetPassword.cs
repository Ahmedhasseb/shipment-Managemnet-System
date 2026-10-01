using Applcation.Comman;
using Applcation.Interface.Iservice;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using model;

namespace Infrastructure.IdentityUser.Servive
{
    public class ResetPassword : IRestPassword
    {
        private readonly UserManager<User> _userManager;

        public ResetPassword(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResultT<bool>> RestartPaswword(string email, string newPassword)
        {
            if (email == null) ResultT<bool>.Failure("Email is required.");
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return ResultT<bool>.Failure("User not found.");
            var toklen = await _userManager.GeneratePasswordResetTokenAsync(user);
            await _userManager.ResetPasswordAsync(user, toklen, newPassword);
            user.AccountTypes=AccountTypes.AccountActive;
          await  _userManager.UpdateAsync(user);
            return ResultT<bool>.Success(true,"Password reset successfully.");
        }
    }
}
