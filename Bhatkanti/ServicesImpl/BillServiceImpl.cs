using Bhatkanti.Models;
using Bhatkanti.Services;
using Microsoft.EntityFrameworkCore;

namespace Bhatkanti.ServicesImpl
{
    public class BillServiceImpl : IBillService
    {
        private readonly ApplicationDbContext _context;

        public BillServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bill>> GetAllBillsAsync()
        {
            return await _context.Bills.ToListAsync();
        }

        public async Task<Bill> GetBillByIdAsync(int id)
        {
            return await _context.Bills.FindAsync(id);
        }

        public async Task<Bill> CreateBillAsync(Bill bill)
        {
            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();
            return bill;
        }

        public async Task<Bill> UpdateBillAsync(Bill bill)
        {
            _context.Bills.Update(bill);
            await _context.SaveChangesAsync();
            return bill;
        }

        public async Task DeleteBillAsync(int id)
        {
            var bill = await _context.Bills.FindAsync(id);
            if (bill != null)
            {
                _context.Bills.Remove(bill);
                await _context.SaveChangesAsync();
            }
        }
    }
}
