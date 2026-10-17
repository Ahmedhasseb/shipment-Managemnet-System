using Applcation.Comman;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applcation.Feature.AuthApplacation.ResetPassword
{
    public  class ResetPasswordCommand:IRequest<Result<bool>>
    {
        public string Email { get; set; }   
        public string Password { get; set; }
    }
}
