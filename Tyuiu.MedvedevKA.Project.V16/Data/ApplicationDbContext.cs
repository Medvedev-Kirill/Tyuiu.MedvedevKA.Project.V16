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
                new() {ProductId = 1, NameProduct = "Product A", Description = "Description A", Price = 10.99m, Quantity = 10, Unit = "��.", Category = "�����������" },
                new() {ProductId = 2, NameProduct = "Product B", Description = "Description B", Price = 25.50m, Quantity = 5, Unit = "��.", Category = "����������" }
            ]);
            builder.Entity<Employee>().HasData([
                new() { EmployeeId = 1, FirstName = "��� 1", LastName = "������� 1", MiddleName = " �������� 1", Position = " ��������� 1" },
                new() { EmployeeId = 2, FirstName = "��� 2", LastName = "������� 2", MiddleName = " �������� 2", Position = " ��������� 2" },
                new() { EmployeeId = 3, FirstName = "��� 3", LastName = "������� 3", MiddleName = " �������� 3", Position = " ��������� 3" },
            ]);

            builder.Entity<Operation>().HasData([
               new() { Id = 1, Date = DateTime.Now.AddDays(-2), OperationType = OperationType.��������, Quantity = 100, ProductId = 1, EmployeeId = 1  },
                new() { Id = 2, Date = DateTime.Now.AddDays(-1), OperationType = OperationType.������, Quantity = 5 , ProductId = 2, EmployeeId = 2}
           ]);

            builder.Entity<Sale>().HasData([
               new() { SaleId = 1, SaleDate = DateTime.Now.AddDays(-5), ProductId = 1, EmployeeId = 1, Quantity = 2, Price = 10.99m },
               new() { SaleId = 2, SaleDate = DateTime.Now.AddDays(-3), ProductId = 2, EmployeeId = 2, Quantity = 1, Price = 25.50m }
           ]);
        }
    }
}
