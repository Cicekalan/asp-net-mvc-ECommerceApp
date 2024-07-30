using System.ComponentModel.DataAnnotations;
namespace ECommerceApp.Core.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string? PaymentId { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        public string CustomerId { get; set; } = null!;
        public ApplicationUser Customer { get; set; } = null!;
        public string SellerId { get; set; } = null!;
        public ApplicationUser Seller { get; set; } = null!;

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}