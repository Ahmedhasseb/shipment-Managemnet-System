using Applcation.Comman;
using Applcation.Interface.IRepository;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applcation
{
    public class CreateLocationHandelr(IuniteOfWork iuniteOfWork) : IRequestHandler<CreateLocationCommand, ResultT<bool>>
    {
        public async Task<ResultT<bool>> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
           var AddLocation = new Location()
           {
               Name = request.Name,
               Type = request.LocationType,
               BasePrice = request.BaseBalance

           };
            await iuniteOfWork.LocationRepository.AddAsync(AddLocation);
            await iuniteOfWork.SaveChangesAsync(cancellationToken);

            if (AddLocation is null)
            {
                return ResultT<bool>.Failure("Location Not Created");
            }
            return ResultT<bool>.Success(true, "Location Created Successfully");
        }
    }
}
