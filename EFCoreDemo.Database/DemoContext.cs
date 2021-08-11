using EFCoreDemo.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCoreDemo.Database
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<ProductSupplier> ProductSuppliers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Address> Address { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>().HasKey(sc => sc.Id);

            modelBuilder.Entity<Order>().HasMany(x => x.OrderDetails).WithOne(x => x.Order);

            modelBuilder.Entity<Product>().HasMany(x => x.OrderDetails).WithOne(x => x.Products);

            modelBuilder.Entity<Order>()
                        .HasOne<Customer>(s => s.Customer)
                        .WithMany(g => g.Orders)
                        .HasForeignKey(s => s.CustomerId);

            modelBuilder.Entity<Order>()
                       .HasOne<Shipper>(s => s.Shipper)
                       .WithMany(g => g.Orders)
                       .HasForeignKey(s => s.ShipperId);

            modelBuilder.Entity<Product>()
                        .HasOne<Category>(s => s.Category)
                        .WithMany(g => g.Products)
                        .HasForeignKey(s => s.CategoryId);

            modelBuilder.Entity<ProductSupplier>().HasKey(sc => new { sc.ProductId, sc.SupplierId });
        }
    }
}
