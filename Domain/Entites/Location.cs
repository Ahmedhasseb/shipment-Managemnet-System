using Domain.Entites.BaseClass;
using Domain.Enums;

namespace Domain.Entites
{
    public class Location : BaseEntity
    {

        public string Name { get; set; }
        public LocationType Type { get; set; }

        public decimal BasePrice { get; set; }

        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<Shipment> FromShipments { get; set; }
        public virtual ICollection<Shipment> ToShipments { get; set; }
        public virtual ICollection<ShipmentRequest> FromShipmentRequests { get; set; }
        public virtual ICollection<ShipmentRequest> ToShipmentRequests { get; set; }
    }
}
