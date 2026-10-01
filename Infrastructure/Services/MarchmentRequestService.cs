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
        public async Task<ResultT<string>> AcceptEmailMerchant(int id, CancellationToken cancellationToken)
        {

            try
            {
                using var transaction = _iuniteOfWork.BeginTransactionAsync(cancellationToken);
                if (id == null)
                    return ResultT<string>.Failure("Merchant ID is invalid.");

                var FindMerchantRequest = await _iuniteOfWork.MerchantRequestRepository.GetByid(id);
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

                    await _userManager.CreateAsync(Createuser);


                    var resultRole = await _userManager.AddToRoleAsync(Createuser, "Merchant");
                    if (!resultRole.Succeeded)
                    {
                        var x = resultRole.Errors.Select(i => i.Description).ToList();
                        return ResultT<string>.Failure("Invaild Role", x);
                    }

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
                    await _iuniteOfWork.MerchanrRepository.AddAsync(CreateMerchant);

                    await _iuniteOfWork.SaveChangesAsync(cancellationToken);

                 await   _iuniteOfWork.CommiteAsync(cancellationToken);



                    FindMerchantRequest.registerionRequest = RegisterionRequestMarchment.Approve;
                    FindMerchantRequest.UserId = Createuser.Id;
                    _iuniteOfWork.MerchantRequestRepository.updateAsync(FindMerchantRequest);



                    var encodedEmail = Uri.EscapeDataString(Createuser.Email);
                    var link = $"https://your-frontend.com/reset-password" + $"?email={encodedEmail}";

                    await _emailService.SendEmailAsync(Createuser.Email, "Marchment Account Aprovee", $" Your merchant account has been approved.\r\n\r\n Please click the following link to create your password:\r\n\r\n  {link}");
                    return ResultT<string>.Success("Merchant request accepted successfully");



                }
            }
            catch (Exception ex)
            {

             await  _iuniteOfWork.RollbackAsync(cancellationToken);
                return ResultT<string>.Failure($"An error occurred while accepting the merchant request: {ex.Message}");
            }
            return ResultT<string>.Failure("Merchant request not found.");

        }

        public async Task<Results> CreateMerchmentRquest(RegisterMerchantRequest registerMerchantRequest, CancellationToken cancellationToken)
        {
            if (registerMerchantRequest is null)
                return Results.Failure("Invaild Forms");

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
                UserId = null


            };
            await _iuniteOfWork.MerchantRequestRepository.AddAsync(createRequest);
            await _iuniteOfWork.SaveChangesAsync(cancellationToken);



            return Results.Success("Your Sent Rquest Done Sucess Please Waiting is Approval");
        }

        public async Task<ResultT<List<GetAllMerchantReponse>>> GetAllMerchamntRequestByBranch(string UserId, CancellationToken cancellationToken)
        {
            var FindBranch = await _iuniteOfWork.ManagerBranchRepository.GetAllAsync(cancellationToken);
            var GetByidBranch= FindBranch.Where(i=>i.UserId==UserId).FirstOrDefault();
            var getAllMerchmentRequest = await _iuniteOfWork.MerchantRequestRepository.GetAllMerchamntRequestByBranch( GetByidBranch.ManagerBranchId  , cancellationToken);
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
            return ResultT<List<GetAllMerchantReponse>>.Success(MapDto, "All Data Merchament Request");

        }

        public async Task<ResultT<List<GetAllMerchantReponse>>> GetAllMerchmentApprove(CancellationToken cancellationToken)
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

            return ResultT<List<GetAllMerchantReponse>>.Success(result, "All Data Merchament Request");
        }

        public async Task<ResultT<List<GetAllMerchantReponse>>> GettAllMarchment(CancellationToken cancellationToken)
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

            return ResultT<List<GetAllMerchantReponse>>.Success(x, "All Data Merchament Request");
        }


    }
}
