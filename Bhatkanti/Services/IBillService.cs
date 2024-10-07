using Bhatkanti.Models;

namespace Bhatkanti.Services
{
    public interface IBillService
    {
        Task<IEnumerable<Bill>> GetAllBillsAsync();
        Task<Bill> GetBillByIdAsync(int id);
        Task<Bill> CreateBillAsync(Bill bill);
        Task<Bill> UpdateBillAsync(Bill bill);
        Task DeleteBillAsync(int id);
    }
}
