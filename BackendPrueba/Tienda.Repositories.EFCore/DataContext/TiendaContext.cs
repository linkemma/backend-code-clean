using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Entities.POCOEntities;

namespace Tienda.Repositories.EFCore.DataContext
{
    public class TiendaContext: DbContext
    {
        public TiendaContext(DbContextOptions<TiendaContext> options): base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(c => c.Id)
                .HasMaxLength(5)
                .IsFixedLength();
            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(15,2)")
                .IsRequired(true);
            modelBuilder.Entity<Order>()
                .Property(o => o.CustomerId)
                .IsRequired()
                .HasMaxLength(5)
                .IsFixedLength();
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProductId });

            modelBuilder.Entity<Order>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(od => od.ProductId);

            modelBuilder.Entity<OrderDetail>()
                .Property(od => od.UnitPrice)
                .HasColumnType("decimal(15,2)")
                .IsRequired(true);

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product { Id = 1, Name = "Arroz", Price = 3800m, Quantity = 40, Stock = 5 },
                    new Product { Id = 2, Name = "Sunte", Price = 1000m, Quantity = 40, Stock = 5 },
                    new Product { Id = 3, Name = "Pastas La Muñeca", Price = 2800m, Quantity = 40, Stock = 5 },
                    new Product { Id = 4, Name = "Macarrones", Price = 1400m, Quantity = 40, Stock = 5 },
                    new Product { Id = 5, Name = "Arina Pan", Price = 5600m, Quantity = 40, Stock = 5 },
                    new Product { Id = 6, Name = "Crema De Dientes", Price = 4800m, Quantity = 40, Stock = 5 },
                    new Product { Id = 7, Name = "Jabon En Polvo", Price = 4300m, Quantity = 40, Stock = 5 },
                    new Product { Id = 8, Name = "Jabon En Barra", Price = 2300m, Quantity = 40, Stock = 5 },
                    new Product { Id = 9, Name = "Condimento", Price = 1200m, Quantity = 40, Stock = 5 },
                    new Product { Id = 10, Name = "Frutiño", Price = 1000m, Quantity = 40, Stock = 5 },
                    new Product { Id = 11, Name = "Chocorramo", Price = 2200m, Quantity = 40, Stock = 5 },
                    new Product { Id = 12, Name = "BomBom Bum", Price = 400m, Quantity = 40, Stock = 5 },
                    new Product { Id = 13, Name = "Bocadollo De Guayaba", Price = 800m, Quantity = 40, Stock = 5 },
                    new Product { Id = 14, Name = "Leche", Price = 3800m, Quantity = 40, Stock = 5 },
                    new Product { Id = 15, Name = "Zucaritas", Price = 7800m, Quantity = 40, Stock = 5 },
                    new Product { Id = 16, Name = "Cafe", Price = 3800m, Quantity = 40, Stock = 5 },
                    new Product { Id = 17, Name = "Leche En Polvo", Price = 10800m, Quantity = 40, Stock = 5 },
                    new Product { Id = 18, Name = "Aceite", Price = 4000m, Quantity = 40, Stock = 5 },
                    new Product { Id = 19, Name = "Coca cola", Price = 5400m, Quantity = 40, Stock = 5 }
                );

            modelBuilder.Entity<Customer>()
                .HasData(
                    new Customer { Id = 1, Name = "Manuel" },
                    new Customer { Id = 2, Name = "Belkis" },
                    new Customer { Id = 3, Name = "Raquel" },
                    new Customer { Id = 4, Name = "Angelica" },
                    new Customer { Id = 5, Name = "Sofia" },
                    new Customer { Id = 6, Name = "Alejandro" },
                    new Customer { Id = 7, Name = "Fanorth" },
                    new Customer { Id = 8, Name = "Diego" },
                    new Customer { Id = 9, Name = "Carlos" },
                    new Customer { Id = 10, Name = "Cesar" }
                );
        }

    }
}
