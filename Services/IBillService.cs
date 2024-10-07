using Bhatkanti_.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bhatkanti_.Services
{
    public interface IBillService
    {
        Task<Bill> CreateBillAsync(Bill bill);
        Task<IEnumerable<Bill>> GetAllBillsAsync();
        Task<Bill> GetBillByIdAsync(int id);
    }
}