using Tyuiu.MedvedevKA.Project.V16.Data.Models;

namespace Tyuiu.MedvedevKA.Project.V16.Data.Interfaces
{
    public interface IInventoryDataService
    {
        Task <IEnumerable<Product>> GetProductsAsync();
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int productId);

        Task <IEnumerable<Employee>> GetEmployeesAsync();
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int employeeId);


        Task <IEnumerable<Operation>> GetOperationsAsync();
        Task AddOperationAsync(Operation operation);
        Task UpdateOperationAsync(Operation operation);
        Task DeleteOperationAsync(int operationId);
        Task<Operation?> GetOperationByIdAsync(int operationId);
 
    }
}
