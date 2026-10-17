using Applcation.Comman;
using Applcation.Feature.Branches;
using Applcation.Interface.IRepository;
using Applcation.Interface.Iservice;
using Domain.Entites;
using Domain.Enums;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CreateBranchServices : ICreateBranchesService
    {
        private readonly IuniteOfWork _iuniteOfWork;

        public CreateBranchServices(IuniteOfWork iuniteOfWork)
        {
            
            _iuniteOfWork = iuniteOfWork;
        }
        public async Task<Result<bool>> CreateBranch(BranchDTO branchDTO,CancellationToken cancellationToken)
        {
            if(branchDTO ==null)
             return Result<bool>.Failure("Branch data is null.", ErrorType.validation);

            var Wallet = new Wallet()
            {
                WalletOwnerType = WalletOwnerType.Branch,
                Balance = 0,
                
            };
           
            var branch = new Branch()
            {
                Name = branchDTO.BranchName,
                EmailBranch = branchDTO.BranchEmail,
                PhoneBranch = branchDTO.BranchPhone,
                Address = branchDTO.BranchAddress,
                LocationId = branchDTO.LocationID,
                Wallet = Wallet
            };
            await _iuniteOfWork.walletRepository.AddAsync(Wallet);
            await _iuniteOfWork.BranchRepository.AddAsync(branch);

            await _iuniteOfWork.SaveChangesAsync(cancellationToken);
            Console.WriteLine(Wallet.Id);
            return Result<bool>.Success(true, "Branch created successfully.");

        }
    }
}
