using ECommerceApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceApp.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.Seller)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SellerId)
                .OnDelete(DeleteBehavior.SetNull); 

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Seller)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SellerId);

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.Price)
                .IsRequired();
            
            builder.Property(p => p.SellerId)
                .IsRequired(false);


            builder.HasData(
                new Product { ProductId = 1, Name = "Smartphone", Price = 299.99m, ImageUrl = "/images/3.jpg", Description = "Latest model smartphone with advanced features.", SellerId = "user1-id", CategoryId = 1 },
                new Product { ProductId = 2, Name = "Laptop", Price = 799.99m, ImageUrl = "/images/1.jpg", Description = "High-performance laptop for all your needs.", SellerId = "user2-id", CategoryId = 1 },
                new Product { ProductId = 3, Name = "T-Shirt", Price = 19.99m, ImageUrl = "/images/4.jpg", Description = "Comfortable cotton t-shirt.", SellerId = "user1-id", CategoryId = 2 },
                new Product { ProductId = 4, Name = "Blender", Price = 49.99m, ImageUrl = "/images/5.jpg", Description = "Powerful blender for your kitchen.", SellerId = "user2-id", CategoryId = 3 },
                new Product { ProductId = 5, Name = "Electric Kettle", Price = 29.99m, ImageUrl = "/images/6.jpg", Description = "Fast boiling electric kettle.", SellerId = "user3-id", CategoryId = 3 },
                new Product { ProductId = 6, Name = "Running Shoes", Price = 59.99m, ImageUrl = "/images/7.jpg", Description = "Lightweight and comfortable running shoes.", SellerId = "user4-id", CategoryId = 2 },
                new Product { ProductId = 7, Name = "Headphones", Price = 99.99m, ImageUrl = "/images/8.jpg", Description = "Noise-cancelling over-ear headphones.", SellerId = "user5-id", CategoryId = 1 },
                new Product { ProductId = 8, Name = "Office Chair", Price = 149.99m, ImageUrl = "/images/9.jpg", Description = "Ergonomic office chair for better posture.", SellerId = "user6-id", CategoryId = 12 },
                new Product { ProductId = 9, Name = "Tablet", Price = 199.99m, ImageUrl = "/images/10.jpg", Description = "Portable and powerful tablet.", SellerId = "user1-id", CategoryId = 1 },
                new Product { ProductId = 10, Name = "Cookware Set", Price = 79.99m, ImageUrl = "/images/11.jpg", Description = "Non-stick cookware set.", SellerId = "user2-id", CategoryId = 3 },
                new Product { ProductId = 11, Name = "Yoga Mat", Price = 25.99m, ImageUrl = "/images/12.jpg", Description = "Eco-friendly yoga mat with non-slip surface.", SellerId = "user3-id", CategoryId = 6 },
                new Product { ProductId = 12, Name = "Sunglasses", Price = 49.99m, ImageUrl = "/images/13.jpg", Description = "Stylish UV protection sunglasses.", SellerId = "user4-id", CategoryId = 2 },
                new Product { ProductId = 13, Name = "Gaming Console", Price = 399.99m, ImageUrl = "/images/14.jpg", Description = "Next-gen gaming console.", SellerId = "user5-id", CategoryId = 1 },
                new Product { ProductId = 14, Name = "Action Camera", Price = 149.99m, ImageUrl = "/images/15.jpg", Description = "Waterproof action camera with 4K recording.", SellerId = "user6-id", CategoryId = 1 },
                new Product { ProductId = 15, Name = "Perfume", Price = 59.99m, ImageUrl = "/images/16.jpg", Description = "Long-lasting fragrance perfume.", SellerId = "user1-id", CategoryId = 8 },
                new Product { ProductId = 16, Name = "Coffee Maker", Price = 89.99m, ImageUrl = "/images/17.jpg", Description = "Automatic drip coffee maker.", SellerId = "user2-id", CategoryId = 3 },
                new Product { ProductId = 17, Name = "Wireless Mouse", Price = 29.99m, ImageUrl = "/images/18.jpg", Description = "Ergonomic wireless mouse.", SellerId = "user3-id", CategoryId = 12 },
                new Product { ProductId = 18, Name = "Smartwatch", Price = 199.99m, ImageUrl = "/images/19.jpg", Description = "Fitness tracker smartwatch.", SellerId = "user4-id", CategoryId = 1 },
                new Product { ProductId = 19, Name = "Bluetooth Speaker", Price = 59.99m, ImageUrl = "/images/20.jpg", Description = "Portable Bluetooth speaker with high sound quality.", SellerId = "user5-id", CategoryId = 1 },
                new Product { ProductId = 20, Name = "Desk Lamp", Price = 39.99m, ImageUrl = "/images/21.jpg", Description = "LED desk lamp with adjustable brightness.", SellerId = "user6-id", CategoryId = 12 }
    );
        }
    }
}