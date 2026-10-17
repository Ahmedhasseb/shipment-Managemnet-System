using Applcation.Comman;
using Applcation.Interface.IRepository;
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
        public class CreateLocationHandelr(IuniteOfWork iuniteOfWork) : IRequestHandler<CreateLocationCommand, Result<bool>>
        {
            public async Task<Result<bool>> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
            {
               var AddLocation = new Location()
               {
                   Name = request.Name,
                   Type = request.LocationType,
                   BasePrice = request.BaseBalance

               };
                await iuniteOfWork.LocationRepository.AddAsync(AddLocation);
                await iuniteOfWork.SaveChangesAsync(cancellationToken);

               
                return Result<bool>.Success(true, "Location Created Successfully");
            }
        }
    }
