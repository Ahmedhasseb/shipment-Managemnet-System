using Applcation.Comman;
using Applcation.Interface.Iservice;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applcation.Feature.ManagerBranch.Command.CreateManager
{
    public class RegisterManagerHandelr(IRegisterManagerBranch registerManagerBranch) : IRequestHandler<RegisterManagerCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(RegisterManagerCommand request, CancellationToken cancellationToken)
        {
          var Result =await registerManagerBranch.RegisterManagerBranches(request.RegisterManagerBranch,cancellationToken);
            return Result;
        }
    }
}
