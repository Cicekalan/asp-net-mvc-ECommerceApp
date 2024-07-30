using ECommerceApp.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceApp.Infrastructure.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(
                new ApplicationUser
                {
                    Id = "user1-id",
                    UserName = "user1@example.com",
                    NormalizedUserName = "USER1@EXAMPLE.COM",
                    Email = "user1@example.com",
                    NormalizedEmail = "USER1@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null!, "Password123*"),
                    SecurityStamp = string.Empty,
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "123-456-7890",
                    ProfilePictureUrl = "/images/ProfilePicture/Profile-picture-1.jpg",
                    StreetAddress = "123 Main St",
                    City = "Hometown",
                    PostalCode = "12345"
                },
                new ApplicationUser
                {
                    Id = "user2-id",
                    UserName = "user2@example.com",
                    NormalizedUserName = "USER2@EXAMPLE.COM",
                    Email = "user2@example.com",
                    NormalizedEmail = "USER2@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null!, "Password123*"),
                    SecurityStamp = string.Empty,
                    FirstName = "Jane",
                    LastName = "Smith",
                    PhoneNumber = "098-765-4321",
                    ProfilePictureUrl = "/images/ProfilePicture/Profile-picture-2.jpg",
                    StreetAddress = "456 Elm St",
                    City = "Hometown",
                    PostalCode = "12345"
                },
                new ApplicationUser
                {
                    Id = "user3-id",
                    UserName = "user3@example.com",
                    NormalizedUserName = "USER3@EXAMPLE.COM",
                    Email = "user3@example.com",
                    NormalizedEmail = "USER3@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null!, "Password123*"),
                    SecurityStamp = string.Empty,
                    FirstName = "Michael",
                    LastName = "Johnson",
                    PhoneNumber = "321-654-0987",
                    ProfilePictureUrl = "/images/ProfilePicture/Profile-picture-3.jpg",
                    StreetAddress = "789 Pine St",
                    City = "Hometown",
                    PostalCode = "12345"
                },
                new ApplicationUser
                {
                    Id = "user4-id",
                    UserName = "user4@example.com",
                    NormalizedUserName = "USER4@EXAMPLE.COM",
                    Email = "user4@example.com",
                    NormalizedEmail = "USER4@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null!, "Password123*"),
                    SecurityStamp = string.Empty,
                    FirstName = "Emily",
                    LastName = "Davis",
                    PhoneNumber = "456-789-0123",
                    ProfilePictureUrl = "/images/ProfilePicture/Profile-picture-4.jpg",
                    StreetAddress = "101 Maple St",
                    City = "Hometown",
                    PostalCode = "12345"
                },
                new ApplicationUser
                {
                    Id = "user5-id",
                    UserName = "user5@example.com",
                    NormalizedUserName = "USER5@EXAMPLE.COM",
                    Email = "user5@example.com",
                    NormalizedEmail = "USER5@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null!, "Password123*"),
                    SecurityStamp = string.Empty,
                    FirstName = "Daniel",
                    LastName = "Wilson",
                    PhoneNumber = "654-321-0987",
                    ProfilePictureUrl = "/images/ProfilePicture/Profile-picture-5.jpg",
                    StreetAddress = "202 Oak St",
                    City = "Hometown",
                    PostalCode = "12345"
                },
                new ApplicationUser
                {
                    Id = "user6-id",
                    UserName = "user6@example.com",
                    NormalizedUserName = "USER6@EXAMPLE.COM",
                    Email = "user6@example.com",
                    NormalizedEmail = "USER6@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null!, "Password123*"),
                    SecurityStamp = string.Empty,
                    FirstName = "Sophia",
                    LastName = "Martinez",
                    PhoneNumber = "789-012-3456",
                    ProfilePictureUrl = "/images/ProfilePicture/Profile-picture-6.jpg",
                    StreetAddress = "303 Birch St",
                    City = "Hometown",
                    PostalCode = "12345"
                }
            );
        }
    }
}
