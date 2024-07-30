using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Application.DTOs
{
    public record ReviewInsertDTO
    {
        [Required(ErrorMessage = "Review content is required.")]
        [StringLength(1000, ErrorMessage = "Review content can't be longer than 1000 characters.")]
        public string Content { get; set; } = null!;
        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }
        public int ProductId { get; set; }
        public string CustomerId { get; set; } = string.Empty;
    }
}