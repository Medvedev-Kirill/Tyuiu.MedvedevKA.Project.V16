using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Tyuiu.MedvedevKA.Project.V16.Data.Models;

namespace Tyuiu.MedvedevKA.Project.V16.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Sale>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Operation>()
                .HasOne(o => o.NameProduct)
                .WithMany()
                .HasForeignKey(o => o.ProductId);

            builder.Entity<Operation>()
                .HasOne(o => o.Employee)
                .WithMany()
                .HasForeignKey(o => o.EmployeeId);

            builder.Entity<Sale>()
                .HasOne(s => s.Product)
                .WithMany()
                .HasForeignKey(s => s.ProductId);

            builder.Entity<Sale>()
                .HasOne(s => s.Employee)
                .WithMany()
                .HasForeignKey(s => s.EmployeeId);

            base.OnModelCreating(builder);

            builder.Entity<Product>().HasData([
                new() {ProductId = 1, NameProduct = "Product A", Description = "Description A", Price = 10.99m, Quantity = 10, Unit = "шт.", Category = "Электроника" },
                new() {ProductId = 2, NameProduct = "Product B", Description = "Description B", Price = 25.50m, Quantity = 5, Unit = "шт.", Category = "Канцелярия" }
            ]);
            builder.Entity<Employee>().HasData([
                new() { EmployeeId = 1, FirstName = "Имя 1", LastName = "Фамилия 1", MiddleName = " Отчество 1", Position = " Должность 1" },
                new() { EmployeeId = 2, FirstName = "Имя 2", LastName = "Фамилия 2", MiddleName = " Отчество 2", Position = " Должность 2" },
                new() { EmployeeId = 3, FirstName = "Имя 3", LastName = "Фамилия 3", MiddleName = " Отчество 3", Position = " Должность 3" },
            ]);

            builder.Entity<Operation>().HasData([
               new() { Id = 1, Date = DateTime.Now.AddDays(-2), OperationType = OperationType.Принесли, Quantity = 100, ProductId = 1, EmployeeId = 1  },
                new() { Id = 2, Date = DateTime.Now.AddDays(-1), OperationType = OperationType.Унесли, Quantity = 5 , ProductId = 2, EmployeeId = 2}
           ]);

            builder.Entity<Sale>().HasData([
               new() { SaleId = 1, SaleDate = DateTime.Now.AddDays(-5), ProductId = 1, EmployeeId = 1, Quantity = 2, Price = 10.99m },
               new() { SaleId = 2, SaleDate = DateTime.Now.AddDays(-3), ProductId = 2, EmployeeId = 2, Quantity = 1, Price = 25.50m }
           ]);
        }
    }
}
