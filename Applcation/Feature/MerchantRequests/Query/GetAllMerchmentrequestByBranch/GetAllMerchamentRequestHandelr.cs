using Applcation.Comman;
using Applcation.Feature.MerchantRequest.DTO;
using Applcation.Interface.IRepository;
using Applcation.Interface.Iservice;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applcation
{
    internal class GetAllMerchamentRequestHandelr(IMarchmentRequestService _marchmentRequestService) : IRequestHandler<GetAllMerchamentRequestQuery, Result<List<GetAllMerchantReponse>>>
    {
        public async Task<Result<List<GetAllMerchantReponse>>> Handle(GetAllMerchamentRequestQuery request, CancellationToken cancellationToken)
        {
            var result =await _marchmentRequestService.GetAllMerchamntRequestByBranch(request.id,cancellationToken);
            return result;
        }
    }
}
