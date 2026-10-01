namespace Domain.Entites
{
    public class MerchantInvition
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool IsUsed { get; set; }
        public Guid Code { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
