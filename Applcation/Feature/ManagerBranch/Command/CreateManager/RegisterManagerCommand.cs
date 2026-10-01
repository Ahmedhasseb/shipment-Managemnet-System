using Applcation.Comman;
using Applcation.Feature.ManagerBranch.DTO;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applcation.Feature.ManagerBranch.Command.CreateManager
{
    public class RegisterManagerCommand : IRequest<ResultT<bool>>
    {
        public RegisterManagerBranchDTO RegisterManagerBranch { get; set; }
    }
}
