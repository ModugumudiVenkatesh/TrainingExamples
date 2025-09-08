using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Models;
namespace Repos
{
    public class EcomDbContext : DbContext
    {
        public EcomDbContext(DbContextOptions<EcomDbContext> options) : base(options) { }


        public DbSet<Customer> Customers {  get; set; }
        public DbSet<Product> Products {  get; set; }
        public DbSet<CartItem> Cart {  get; set; }
        public DbSet<Order> Orders {  get; set; }
        public DbSet<OrderItem> OrderItems {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Unique email for customers (optional but useful)
            modelBuilder.Entity<Customer>()
            .HasIndex(c => c.Email)
            .IsUnique();


            // Each cart row links a customer and a product; prevent duplicates per customer/product
            modelBuilder.Entity<CartItem>()
            .HasIndex(ci => new { ci.CustomerId, ci.ProductId })
            .IsUnique();


            // Decimal mapping already set via attribute on Product.Price
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.TotalPrice)
            .HasColumnType("decimal(18, 2)");
            });
        }
    }
}
