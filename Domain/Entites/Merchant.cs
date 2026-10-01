using Domain.Entites.BaseClass;

namespace Domain.Entites
{
    public class Merchant : BaseEntity
    {
        public string UserId { get; set; }
        public string name { get; set; }
        public string Email { get; set; }
        public string NameCompany { get; set; }
        public string PhoneMerchant { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public int WalletId { get; set; }
        public int BranchId { get; set; }

        public virtual Wallet Wallet { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual ICollection<EmployeeMerchant> MerchantEmployees { get; set; }
        public virtual ICollection<Shipment> Shipments { get; set; }
        public virtual ICollection<ShipmentRequest> ShipmentRequests { get; set; }
    }
}
