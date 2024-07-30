using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Core.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Review content can't be longer than 1000 characters.")]
        public string Content { get; set; } = null!;

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")] 
        public int Rating { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public string CustomerId { get; set; } = null!;

        public Product Product { get; set; } = null!;
        public ApplicationUser Customer { get; set; } = null!;
    }
}
