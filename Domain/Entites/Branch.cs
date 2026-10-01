using Domain.Entites.BaseClass;

namespace Domain.Entites
{
    public class Branch : BaseEntity
    {

        public string Name { get; set; }
        public string EmailBranch { get; set; }
        public string PhoneBranch { get; set; }
        public string Address { get; set; }
        public int WalletId { get; set; }

        public virtual Wallet Wallet { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public virtual ManagerBranch ManagerBranch { get; set; }
        public virtual ICollection<EmployeeBranch> EmployeeBranches { get; set; }
        public virtual ICollection<Merchant> Merchants { get; set; }
        public virtual ICollection<Shipment> Shipments { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }

        public virtual ICollection<MerchantRequests> MerchantRequests { get; set; }
    }
}
