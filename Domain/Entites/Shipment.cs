using Domain.Entites.BaseClass;
using Domain.Enums;

namespace Domain.Entites
{
    public class Shipment : BaseEntity
    {
        public string TrackingNumber { get; set; }
        public int MerchantId { get; set; }
        public virtual Merchant Merchant { get; set; }
        public int MerchantEmployeeId { get; set; }
        public virtual EmployeeMerchant MerchantEmployee { get; set; }
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public int AssignedEmployeeId { get; set; }
        public virtual EmployeeBranch EmployeeBranch { get; set; }
        public int DriverId { get; set; }
        public virtual Driver Driver { get; set; }
        public string UserId { get; set; }
        public int ShipmentRequestId { get; set; }
        public virtual ShipmentRequest ShipmentRequest { get; set; }
        public DateTime Created { get; set; }
        public int FromLocationId { get; set; }
        public Location FromLocation { get; set; }

        public int ToLocationId { get; set; }
        public Location ToLocation { get; set; }
        public DateTime? PickupDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public decimal ShippingCost { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public ShipmentStatus status { get; set; }

        public virtual ICollection<ShipmentTracking> ShipmentTrackings { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<WalletTransaction> WalletTransactions { get; set; }
    }
}
