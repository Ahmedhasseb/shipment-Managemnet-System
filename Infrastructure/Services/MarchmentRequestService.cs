using Applcation.Comman;
using Applcation.Feature.MerchantRequest.DTO;
using Applcation.Interface.IRepository;
using Applcation.Interface.Iservice;
using Domain.Entites;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using model;

namespace Infrastructure.Services
{
    public class MarchmentRequestService : IMarchmentRequestService
    {
        private readonly IEmailService _emailService;
        private readonly IuniteOfWork _iuniteOfWork;
        private readonly UserManager<User> _userManager;

        public MarchmentRequestService(IEmailService emailService, IuniteOfWork iuniteOfWork, UserManager<User> userManager)
        {
            _emailService = emailService;
            _iuniteOfWork = iuniteOfWork;
            _userManager = userManager;
        }
        public async Task<Result<string>> AcceptEmailMerchant(int id, CancellationToken cancellationToken)
        {

            try
            {
                using var transaction = _iuniteOfWork.BeginTransactionAsync(cancellationToken);
                if (id <=0)
                    return Result<string>.Failure("Merchant ID is invalid.", ErrorType.validation);

                var FindMerchantRequest = await _iuniteOfWork.MerchantRequestRepository.GetByidAsync(id);
                if (FindMerchantRequest != null)
                {



                    var Createuser = new User()
                    {
                        FirstName = FindMerchantRequest.FName,
                        Email = FindMerchantRequest.Email,
                        UserName = FindMerchantRequest.Email.Split("@")[0],
                        AccountTypes = AccountTypes.AcoountSetPassword,
                        LastName = FindMerchantRequest.LName,
                        PhoneNumber = FindMerchantRequest.PhoneMerchant,
                        DateOfBirth = FindMerchantRequest.Created,


                    };

                  var Result=  await _userManager.CreateAsync(Createuser);


                    if (!Result.Succeeded)
                    {
                        var x = Result.Errors.Select(i => i.Description).ToList();
                        return Result<string>.Failure("Failed to create Marchment", ErrorType.failure, x);
                    }
                    var resultRole = await _userManager.AddToRoleAsync(Createuser, "Merchant");

                    // Create wallet for the merchant
                    var wallet = new Wallet
                    {
                        Balance = 0,
                        WalletOwnerType = WalletOwnerType.Merchant,


                    };
                    //Create informatiom merchant
                    var CreateMerchant = new Merchant
                    {
                        UserId = Createuser.Id,
                        name = FindMerchantRequest.FName + FindMerchantRequest.LName,
                        Email = FindMerchantRequest.Email,
                        NameCompany = FindMerchantRequest.CompanyName,
                        PhoneMerchant = FindMerchantRequest.PhoneMerchant,
                        Address = FindMerchantRequest.Address,
                        IsActive = true,
                        Created = DateTime.UtcNow,
                        Wallet = wallet

                    };

                    await _iuniteOfWork.walletRepository.AddAsync(wallet);
                    await _iuniteOfWork.MerchmentRepository.AddAsync(CreateMerchant);
                    FindMerchantRequest.registerionRequest = RegisterionRequestMarchment.Approve;
                    FindMerchantRequest.UserId = Createuser.Id;
                     _iuniteOfWork.MerchantRequestRepository.update(FindMerchantRequest);

                    await _iuniteOfWork.SaveChangesAsync(cancellationToken);

                 await   _iuniteOfWork.CommiteAsync(cancellationToken);






                    var encodedEmail = Uri.EscapeDataString(Createuser.Email);
                    var link = $"https://your-frontend.com/reset-password" + $"?email={encodedEmail}";

                    await _emailService.SendEmailAsync(Createuser.Email, "Marchment Account Aprovee", $" Your merchant account has been approved.\r\n\r\n Please click the following link to create your password:\r\n\r\n  {link}");
                    return Result<string>.Success("Merchant request accepted successfully");



                }
            }
            catch (Exception ex)
            {

             await  _iuniteOfWork.RollbackAsync(cancellationToken);
                return Result<string>.Failure($"An error occurred while accepting the merchant request: {ex.Message}", ErrorType.failure);
            }
            return Result<string>.Failure("Merchant request not found.", ErrorType.notfound);
        }

        public async Task<Result> CreateMerchmentRquest(RegisterMerchantRequest registerMerchantRequest, CancellationToken cancellationToken)
        {
            if (registerMerchantRequest is null)
                return Result.Failure(ErrorType.validation,"Invaild Forms");

            var createRequest = new MerchantRequests()
            {
                Email = registerMerchantRequest.Email,
                Address = registerMerchantRequest.Address,
                CompanyName = registerMerchantRequest.CompanyName,
                PhoneMerchant = registerMerchantRequest.PhoneMerchant,
                FName = registerMerchantRequest.FName,
                LName = registerMerchantRequest.LName,
                Created = DateTime.UtcNow,
                registerionRequest = RegisterionRequestMarchment.pending,
                


            };
            await _iuniteOfWork.MerchantRequestRepository.AddAsync(createRequest);
            await _iuniteOfWork.SaveChangesAsync(cancellationToken);



            return Result.Success("Your Sent Rquest Done Sucess Please Waiting is Approval");
        }

        public async Task<Result<List<GetAllMerchantReponse>>> GetAllMerchamntRequestByBranch(string UserId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(UserId))
                return Result<List<GetAllMerchantReponse>>.Failure("User ID is required.",ErrorType.validation);
            var branch = await _iuniteOfWork.ManagerBranchRepository.GetManagerBranchByIdAsync(UserId, cancellationToken);
            if (branch == null)
                return Result<List<GetAllMerchantReponse>>.Failure("Branch not found ",ErrorType.notfound);
            var getAllMerchmentRequest = await _iuniteOfWork.MerchantRequestRepository.GetAllMerchamntRequestByBranch( branch.ManagerBranchId  , cancellationToken);
            var MapDto = getAllMerchmentRequest.Select(i => new GetAllMerchantReponse
            {
                Id = i.Id,
                Address = i.Address,
                CompanyName = i.CompanyName,
                Email = i.Email,
                Name = i.FName + i.LName,
                PhoneMerchant = i.PhoneMerchant,
                UserId = i.UserId,
                BranchId=i.BranchId
            }).ToList();
            return Result<List<GetAllMerchantReponse>>.Success(MapDto, "Merchant requests retrieved successfully");

        }

        public async Task<Result<List<GetAllMerchantReponse>>> GetAllMerchmentApprove(CancellationToken cancellationToken)
        {
            var GetAllMerhmantAprove = await _iuniteOfWork.MerchantRequestRepository.GetAllMerchantsAproved(cancellationToken);
            var result = GetAllMerhmantAprove.Select(i => new GetAllMerchantReponse
            {
                Address = i.Address,
                CompanyName = i.CompanyName,
                Email = i.Email,
                Name = i.FName + i.LName,
                PhoneMerchant = i.PhoneMerchant,
                UserId = i.UserId
            }).ToList();

            return Result<List<GetAllMerchantReponse>>.Success(result, "Merchant requests Approved retrieved successfully");
        }

        public async Task<Result<List<GetAllMerchantReponse>>> GettAllMarchment(CancellationToken cancellationToken)
        {
            var Result = await _iuniteOfWork.MerchantRequestRepository.GetAllAsync(cancellationToken);
            var x = Result.Select(i => new GetAllMerchantReponse
            {
                Id = i.Id,
                Address = i.Address,
                CompanyName = i.CompanyName,
                Email = i.Email,
                Name = i.FName + i.LName,
                PhoneMerchant = i.PhoneMerchant,
                UserId = i.UserId,


            }).ToList();

            return Result<List<GetAllMerchantReponse>>.Success(x, "All Merchant requests retrieved successfully");
        }


    }
}
