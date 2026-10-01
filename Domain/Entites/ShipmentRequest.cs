using Domain.Entites.BaseClass;

namespace Domain.Entites
{
    public class ShipmentRequest : BaseEntity
    {
        public int MerchantId { get; set; }
        public Merchant Merchant { get; set; }
        public int FromLocationId { get; set; }
        public Location FromLocation { get; set; }
        public int ToLocationId { get; set; }
        public Location ToLocation { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public int AssignedEmployeeId { get; set; }
        public EmployeeBranch EmployeeBranch { get; set; }
        public int ShipmentId { get; set; }
        public virtual Shipment Shipment { get; set; }
        public int MerchantEmployeeId { get; set; }
        public EmployeeMerchant EmployeeMerchant { get; set; }
    }
}
