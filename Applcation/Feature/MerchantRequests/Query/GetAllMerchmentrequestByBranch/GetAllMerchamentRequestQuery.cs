using Applcation.Comman;
using Applcation.Feature.MerchantRequest.DTO;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applcation
{
    public class GetAllMerchamentRequestQuery : IRequest<Result<List<GetAllMerchantReponse>>>
    {
        public string id { get; set; }
    }
}
