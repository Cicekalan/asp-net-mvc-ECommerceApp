using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name can't be longer than 50 characters.")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name can't be longer than 50 characters.")]
        public string LastName { get; set; } = null!;

        [DataType(DataType.Date)]
        [Display(Name = "Creation Date")]
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        [Required(ErrorMessage = "Street address is required.")]
        [StringLength(100, ErrorMessage = "Street address can't be longer than 100 characters.")]
        public string StreetAddress { get; set; } = null!;

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "City can't be longer than 50 characters.")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "Postal code is required.")]
        [StringLength(20, ErrorMessage = "Postal code can't be longer than 20 characters.")]
        public string PostalCode { get; set; } = null!;
        public string? ProfilePictureUrl { get; set; } = "/images/ProfilePicture/default-profile.jpg";
        public ICollection<Product>? Products { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}