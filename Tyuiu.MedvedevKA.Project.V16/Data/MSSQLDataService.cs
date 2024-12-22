using Microsoft.EntityFrameworkCore;
using Tyuiu.MedvedevKA.Project.V16.Data.Interfaces;
using Tyuiu.MedvedevKA.Project.V16.Data.Models;
using System.Globalization;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace Tyuiu.MedvedevKA.Project.V16.Data
{
    public class MSSQLDataService(ApplicationDbContext context) : IInventoryDataService,ISalesDataService
    {

        public async Task AddEmployeeAsync(Employee employee)
        {
            await using (var transaction = await context.Database.BeginTransactionAsync()) // Add transaction for atomicity
            {
                try
                {
                    context.Employees.Add(employee);
                    await context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    // Log the exception (replace with your preferred logging mechanism)
                    Console.Error.WriteLine($"Error adding product: {ex.Message}");
                    throw;
                }
            }
        }

        public async Task AddOperationAsync(Operation operation)
        {
            await using (var transaction = await context.Database.BeginTransactionAsync()) // Add transaction for atomicity
            {
                try
                {
                    context.Operations.Add(operation);
                    await context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    // Log the exception (replace with your preferred logging mechanism)
                    Console.Error.WriteLine($"Error adding product: {ex.Message}");
                    throw;
                }
            }
        }

        public async Task AddProductAsync(Product product)
        {
            await using (var transaction = await context.Database.BeginTransactionAsync()) // Add transaction for atomicity
            {
                try
                {
                    context.Products.Add(product);
                    await context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    // Log the exception (replace with your preferred logging mechanism)
                    Console.Error.WriteLine($"Error adding product: {ex.Message}");
                    throw;
                }
            }
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var employee = await context.Employees.FindAsync(employeeId);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await context.Products.FindAsync(productId);
            if (product != null)
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
            }
        }
        public async Task DeleteOperationAsync(int operationId)
        {
            var operation = await context.Operations.FindAsync(operationId);
            if (operation != null)
            {
                context.Operations.Remove(operation);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await context.Employees.ToArrayAsync();
        }

        public async Task<IEnumerable<Operation>> GetOperationsAsync()
        {
            return await context.Operations
                .Include(o => o.NameProduct)
                .Include(o => o.Employee)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await context.Products.ToArrayAsync();
        }

        public async Task<IEnumerable<Sale>> GetSalesAsync(DateTime startDate, DateTime endDate)
        {
            return await context.Sales
            .Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate)
            .Include(s => s.Product)  
            .Include(s => s.Employee) 
            .ToListAsync();

        }

        
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            context.Employees.Update(employee);
            await context.SaveChangesAsync();
            
        }

        public async Task UpdateProductAsync(Product product)
        {
            context.Products.Update(product);
            await context.SaveChangesAsync(); 
        }
        public async Task UpdateOperationAsync(Operation operation)
        {
            context.Operations.Update(operation);
            await context.SaveChangesAsync();
        }

        public async Task<Operation?> GetOperationByIdAsync(int operationId)
        {
            return await context.Operations.FindAsync(operationId);
        }

    }
}
