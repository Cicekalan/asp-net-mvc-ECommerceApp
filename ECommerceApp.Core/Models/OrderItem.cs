    using System.ComponentModel.DataAnnotations;

    namespace ECommerceApp.Core.Models
    {
        public class OrderItem
        {
            public int OrderItemId { get; set; }

            [Required]
            public int OrderId { get; set; }


            [Required]
            public int ProductId { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
            public int Quantity { get; set; }

            [Required]
            [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
            public decimal Price { get; set; }
            public Order Order { get; set; } = null!;
            public Product Product { get; set; } = null!;
        }
    }