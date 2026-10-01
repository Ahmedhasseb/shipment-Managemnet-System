using Domain.Entites.BaseClass;

namespace Domain.Entites
{
    public class Driver : BaseEntity
    {

        public string UserId { get; set; }

        public string name { get; set; }
        public string VehicleType { get; set; }
        public string VehiclePlateNumber { get; set; }
        public bool IsAvailable { get; set; }
        public int WalletId { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public virtual Wallet Wallet { get; set; }
        public virtual ICollection<Shipment> Shipments { get; set; }
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
