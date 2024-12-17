using Tyuiu.MedvedevKA.Project.V16.Data.Models;

namespace Tyuiu.MedvedevKA.Project.V16.Data.Interfaces
{
    public interface ISalesDataService
    {
        Task<IEnumerable<Sale>> GetSalesAsync(DateTime startDate, DateTime endDate);
        Task<string> GenerateSalesReportAsync(DateTime startDate, DateTime endDate);
    }
}

