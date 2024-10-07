using Bhatkanti_.Data;
using Bhatkanti_.Models;
using Bhatkanti_.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bhatkanti_.ServicesImpl
{
    public class BillService : IBillService
    {
        private readonly TravelGuideContext _context;

        public BillService(TravelGuideContext context)
        {
            _context = context;
        }

        public async Task<Bill> CreateBillAsync(Bill bill)
        {
            // Calculate TotalAmount
            bill.TotalAmount = bill.GuideFees + bill.GST + bill.PlatformFees;

            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();
            return bill;
        }

        public async Task<IEnumerable<Bill>> GetAllBillsAsync()
        {
            return await _context.Bills.ToListAsync();
        }

        public async Task<Bill> GetBillByIdAsync(int id)
        {
            return await _context.Bills.FindAsync(id);
        }
    }
}