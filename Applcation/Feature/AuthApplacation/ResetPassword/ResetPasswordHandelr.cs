using Applcation.Comman;
using Applcation.Interface.Iservice;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applcation.Feature.AuthApplacation.ResetPassword
{
    public class ResetPasswordHandelr(IRestPassword resetPasswordService) : IRequestHandler<ResetPasswordCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
           var Result =await resetPasswordService.RestartPaswword(request.Email,request.Password);
            return Result;
        }
    }
}
