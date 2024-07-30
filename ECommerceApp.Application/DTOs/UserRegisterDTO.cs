using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Application.DTOs
{
    public record UserRegisterDTO
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name can't be longer than 50 characters.")]
        public string FirstName { get; init; } = null!;

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name can't be longer than 50 characters.")]
        public string LastName { get; init; } = null!;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; init; } = null!;

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; init; } = null!;

        [Required(ErrorMessage = "Street address is required.")]
        [StringLength(100, ErrorMessage = "Street address can't be longer than 100 characters.")]
        public string StreetAddress { get; init; } = null!;

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "City can't be longer than 50 characters.")]
        public string City { get; init; } = null!;

        [Required(ErrorMessage = "Postal code is required.")]
        [StringLength(20, ErrorMessage = "Postal code can't be longer than 20 characters.")]
        public string PostalCode { get; init; } = null!;
    }
}
