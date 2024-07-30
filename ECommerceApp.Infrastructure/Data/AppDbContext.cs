using System.Reflection;
using ECommerceApp.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace ECommerceApp.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        public void CreateAddShoppingCartTrigger()
        {
            var sql = @"
        CREATE TRIGGER trg_AddShoppingCart
        AFTER INSERT ON aspnetusers
        FOR EACH ROW
        BEGIN
            INSERT INTO shoppingcarts (CustomerId)
            VALUES (NEW.Id);
        END;";

            this.Database.ExecuteSqlRaw(sql);
        }


    }
}