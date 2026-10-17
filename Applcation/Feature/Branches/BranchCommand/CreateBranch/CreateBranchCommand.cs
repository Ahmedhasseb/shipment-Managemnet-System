using Applcation.Comman;
using Applcation.Feature.Branches;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applcation
{
    public class CreateBranchCommand : IRequest<Result<bool>>
    {
        public BranchDTO branchDTO { get; set; }
    }
}
