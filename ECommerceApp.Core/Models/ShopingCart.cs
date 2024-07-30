using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Core.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }

        [Required]
        public string CustomerId { get; set; } = null!;

        public ApplicationUser Customer { get; set; } = null!;

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
