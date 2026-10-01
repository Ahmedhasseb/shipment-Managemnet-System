using Domain.Enums;

namespace Domain.Entites
{
    public class Payment
    {
        public int Id { get; set; }

        public int ShipmentId { get; set; }

        public decimal Amount { get; set; }

        public PaymentMethod Method { get; set; }

        public PaymentStatus Status { get; set; }

        public DateTime PaidAt { get; set; }
        public virtual Shipment Shipment
        {
            get; set;
        }
    }
}
