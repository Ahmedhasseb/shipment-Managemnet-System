using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Applcation.Feature.Locations.Command
{
    public class LocationVailditor:AbstractValidator<CreateLocationCommand>
    {
        public LocationVailditor()
        {
                RuleFor(i => i.Name).NotEmpty().WithMessage("Please Enter the Location Name is Requierd");
            RuleFor(i => i.LocationType).NotEmpty().WithMessage("Please Enter the Location Type is Requierd");
            RuleFor(i => i.BaseBalance).NotEmpty().WithMessage("Please Enter the Base Balance is Requierd");
        }
    }
}
