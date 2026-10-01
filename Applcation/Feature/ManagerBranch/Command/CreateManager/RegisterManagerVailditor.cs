using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applcation.Feature.ManagerBranch.Command.CreateManager
{
    public class RegisterManagerVailditor:AbstractValidator<RegisterManagerCommand>
    {
        public RegisterManagerVailditor()
        {
            RuleFor(x => x.RegisterManagerBranch).NotNull().WithMessage("RegisterManagerBranch cannot be null");
        }
    }
}
