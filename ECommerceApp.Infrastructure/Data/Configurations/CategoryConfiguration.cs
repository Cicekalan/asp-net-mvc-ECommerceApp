using ECommerceApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceApp.Infrastructure.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { CategoryId = 1, Name = "Electronics" },
                new Category { CategoryId = 2, Name = "Clothing" },
                new Category { CategoryId = 3, Name = "Home & Kitchen" },
                new Category { CategoryId = 4, Name = "Books" },
                new Category { CategoryId = 5, Name = "Toys & Games" },
                new Category { CategoryId = 6, Name = "Sports & Outdoors" },
                new Category { CategoryId = 7, Name = "Automotive" },
                new Category { CategoryId = 8, Name = "Beauty & Personal Care" },
                new Category { CategoryId = 9, Name = "Health & Household" },
                new Category { CategoryId = 10, Name = "Grocery & Gourmet Food" },
                new Category { CategoryId = 11, Name = "Pet Supplies" },
                new Category { CategoryId = 12, Name = "Office Products" },
                new Category { CategoryId = 13, Name = "Tools & Home Improvement" },
                new Category { CategoryId = 14, Name = "Industrial & Scientific" }
            );

        }
    }
}