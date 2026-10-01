using Domain.Entites.BaseClass;
using Domain.Enums;

namespace Domain.Entites
{
    public class Wallet 
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public WalletOwnerType WalletOwnerType { get; set; }
       
        public virtual ICollection<WalletTransaction> WalletTransactions { get; set; }
    }
}
