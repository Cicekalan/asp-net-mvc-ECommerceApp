using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Core.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }

        [Required]
        public int ShoppingCartId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
        
        public ShoppingCart ShoppingCart { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}