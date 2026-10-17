using Applcation.Comman;
using Domain.Entites;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applcation
{
    public class CreateLocationCommand:IRequest<Result<bool>>
    {
        public string Name { get; set; }    
        public LocationType LocationType { get; set; }
        public decimal BaseBalance { get; set; }    
    }
}
