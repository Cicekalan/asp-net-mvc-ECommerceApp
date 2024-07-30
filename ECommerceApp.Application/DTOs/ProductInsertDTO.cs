using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Application.DTOs
{
    public record ProductInsertDTO
    {
        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, ErrorMessage = "Product name can't be longer than 100 characters.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Product description is required.")]
        [StringLength(500, ErrorMessage = "Product description can't be longer than 500 characters.")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Product price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Category ID is required.")]
        public int CategoryId { get; set; }

        public string? ImageUrl { get; set; }

        public string SellerId { get; set; } = string.Empty;
        
    }
}