using Domain.Entites.BaseClass;

namespace Domain.Entites
{
    public class EmployeeBranch : BaseEntity
    {

        public int BranchId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string permisson { get; set; }
        public Branch Branch { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }

        public Driver Drivers { get; set; }
        public virtual ICollection<Shipment> Shipments { get; set; }
        public virtual ICollection<ShipmentRequest> ShipmentRequests { get; set; }


    }
}
