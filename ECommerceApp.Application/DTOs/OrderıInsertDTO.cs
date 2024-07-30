using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Application.DTOs
{
    public record OrderDTO
    {
        public int OrderId { get; init; }

        [Required]
        public DateTime OrderDate { get; init; }

        [Required]
        public decimal TotalAmount { get; init; }

        [Required]
        public string CustomerId { get; init; } = null!;
        [Required]
        public string SellerId { get; init; } = null!;

    }
}