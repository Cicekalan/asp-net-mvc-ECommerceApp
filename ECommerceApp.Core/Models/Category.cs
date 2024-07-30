using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Core.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(50, ErrorMessage = "Category name can't be longer than 50 characters.")]
        public string Name { get; set; } = null!;
        public ICollection<Product>? Products { get; set; }
    }
}