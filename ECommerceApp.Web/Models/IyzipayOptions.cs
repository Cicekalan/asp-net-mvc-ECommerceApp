namespace ECommerceApp.Web.Models
{
    public class IyzipayOptions : Iyzipay.Options
    {
        public string? ApiKey { get; set; } 
        public string? SecretKey { get; set; }
        public string? BaseUrl { get; set; }
    }
}