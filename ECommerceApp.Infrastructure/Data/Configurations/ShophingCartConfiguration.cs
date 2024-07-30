using ECommerceApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceApp.Infrastructure.Data.Configurations
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasOne(sc => sc.Customer)
                .WithOne(c => c.ShoppingCart)
                .HasForeignKey<ShoppingCart>(sc => sc.CustomerId);

            builder.HasData(
                new ShoppingCart { ShoppingCartId = 1, CustomerId = "user1-id" },
                new ShoppingCart { ShoppingCartId = 2, CustomerId = "user2-id" },
                new ShoppingCart { ShoppingCartId = 3, CustomerId = "user3-id" },
                new ShoppingCart { ShoppingCartId = 4, CustomerId = "user4-id" },
                new ShoppingCart { ShoppingCartId = 5, CustomerId = "user5-id" },
                new ShoppingCart { ShoppingCartId = 6, CustomerId = "user6-id" }
            );
        }
    }
}