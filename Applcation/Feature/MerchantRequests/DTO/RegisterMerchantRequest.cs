namespace Applcation.Feature.MerchantRequest.DTO
{
    public record RegisterMerchantRequest
    {

        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string PhoneMerchant { get; set; }
        public string Address { get; set; }

        public DateTime Created { get; set; }
    }
}
