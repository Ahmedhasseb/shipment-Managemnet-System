using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applcation.Feature.Branches.BranchCommand.CreateBranch
{
    public class CreateBranchVailditor:AbstractValidator<CreateBranchCommand>
    {
        public CreateBranchVailditor()
        {
            RuleFor(x => x.branchDTO.BranchName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.branchDTO.BranchAddress)
                .NotEmpty()
                .MaximumLength(200);
            RuleFor(x => x.branchDTO.BranchEmail)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(100);
            RuleFor(x => x.branchDTO.BranchPhone)
                .NotEmpty()
                .Matches(@"^\+?\d{10,15}$")
                .WithMessage("Invalid phone number format.");
            RuleFor(x => x.branchDTO.LocationID)
                .NotEmpty();    
        }
    }
}
