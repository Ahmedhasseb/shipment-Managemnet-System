using Domain.Entites.BaseClass;
using Domain.Enums;

namespace Domain.Entites
{
    public class MerchantRequests : BaseEntity
    {
        public string UserId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string PhoneMerchant { get; set; }
        public string Address { get; set; }
        public RegisterionRequestMarchment registerionRequest { get; set; }
        public DateTime Created { get; set; }
        public  int BranchId { get; set; }
        public Branch Branch { get; set; }


    }
}
