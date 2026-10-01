using Domain.Entites.BaseClass;

namespace Domain.Entites
{
    public class EmployeeMerchant : BaseEntity
    {
        public int MerchantId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string permisson { get; set; }
        public virtual Merchant Merchant { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public virtual ICollection<Shipment> Shipments { get; set; }
        public virtual ICollection<ShipmentRequest> ShipmentRequests { get; set; }


    }
}
