using Applcation.Comman;
using Applcation.Interface.Iservice;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applcation
{
    public class CreateBranchHandelr(ICreateBranchesService _createBranchesService) : IRequestHandler<CreateBranchCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
           var Result=await _createBranchesService.CreateBranch(request.branchDTO, cancellationToken);
            return Result;
        }
    }
}
