using Domain.Entites.BaseClass;
using Domain.Enums;

namespace Domain.Entites
{
    public class WalletTransaction : BaseEntity
    {


        public int WalletId { get; set; }

        public int? ShipmentId { get; set; }
        public decimal Amount { get; set; }

        public TransactionType Type { get; set; } // Credit / Debit

        public WalletTransactionReason Reason { get; set; }


        public DateTime CreatedAt { get; set; }
        public virtual Wallet Wallet { get; set; }
        public virtual Shipment Shipment { get; set; }
    }
}

