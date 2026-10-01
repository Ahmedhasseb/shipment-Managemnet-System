using Applcation.Comman;
using Applcation.Feature.ManagerBranch.DTO;
using Applcation.Interface.IRepository;
using Applcation.Interface.Iservice;
using Domain.Entites;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using model;

namespace Infrastructure.IdentityUser.Servive
{
    public class RegisterMangerBranch : IRegisterManagerBranch
    {
        private readonly IuniteOfWork _iuniteOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;

        public RegisterMangerBranch(IuniteOfWork iuniteOfWork, UserManager<User> userManager,IEmailService emailService)
        {
            _iuniteOfWork = iuniteOfWork;
            _userManager = userManager;
            _emailService = emailService;
        }
        public async Task<ResultT<bool>> RegisterManagerBranches(RegisterManagerBranchDTO registerManagerBranchDTO, CancellationToken cancellationToken)
        {
           using var transaction=  _iuniteOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                if (registerManagerBranchDTO.Email == null || registerManagerBranchDTO.Name == null || registerManagerBranchDTO.BranchId == 0)
                {
                    return ResultT<bool>.Failure("All fields are required.");
                }
                var Password = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper() + "a1";
                var CreateUser = new User
                {
                    Email = registerManagerBranchDTO.Email,
                    FirstName = registerManagerBranchDTO.Name,
                    UserName = registerManagerBranchDTO.Email.Split('@')[0],
                    AccountTypes = AccountTypes.AcoountSetPassword,


                };
                var Result = await _userManager.CreateAsync(CreateUser, Password);
                if (!Result.Succeeded)
                {
                    var errors = Result.Errors.Select(e => e.Description).ToList();
                    return ResultT<bool>.Failure("Failed to create manager branch.", errors);
                }
                await _userManager.AddToRoleAsync(CreateUser, "Manager");

                var CraeteMangerBranch = new ManagerBranch
                {
                    UserId = CreateUser.Id,
                    Name = registerManagerBranchDTO.Name,
                    Email = registerManagerBranchDTO.Email,
                    IsActive = true,
                    ManagerBranchId = registerManagerBranchDTO.BranchId
                };
                await _iuniteOfWork.ManagerBranchRepository.AddAsync(CraeteMangerBranch);
                await _iuniteOfWork.SaveChangesAsync(cancellationToken);
              await  _iuniteOfWork.CommiteAsync(cancellationToken);
                var encodedEmail = Uri.EscapeDataString(CreateUser.Email);
                var link = $"https://your-frontend.com/reset-password" + $"?email={encodedEmail}";

                await _emailService.SendEmailAsync(CreateUser.Email, "ser Manager Branch Account Approved", $" Your manager branch account has been approved.\r\n\r\n Please click the following link to create your password:\r\n\r\n  {link}+ this is password only registery {Password}");


                return ResultT<bool>.Success(true, "Manager branch registered successfully.");


            }
            catch (Exception ex)
            {

                await _iuniteOfWork.RollbackAsync(cancellationToken);
                return ResultT<bool>.Failure($"An error occurred while registering the manager branch: {ex.Message}");
            }
            
        }
    }
}
