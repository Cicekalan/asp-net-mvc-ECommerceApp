using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Application.DTOs
{
    public record UserLoginDTO
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; init; } = null!;

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; init; } = null!;
    }
}