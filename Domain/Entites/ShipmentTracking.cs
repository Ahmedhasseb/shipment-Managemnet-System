using Domain.Entites.BaseClass;
using Domain.Enums;

namespace Domain.Entites
{
    public class ShipmentTracking : BaseEntity
    {

        public int ShipmentId { get; set; }
        public string EmployeeShipmentId { get; set; } //مسئول عن تتبع الشحنة 
        public string Location { get; set; }
        public string Notes { get; set; }
        public PaymentStatus Status { get; set; }
        public virtual Shipment Shipment { get; set; }
        public virtual EmployeeBranch EmployeeBranch { get; set; }
    }
}
