using Bhatkanti.Models;
using Bhatkanti.Services;
using Microsoft.EntityFrameworkCore;

namespace Bhatkanti.ServicesImpl
{
    public class HelpServiceImpl : IHelpService
    {
        private readonly ApplicationDbContext _context;

        public HelpServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Help>> GetAllHelpQueriesAsync()
        {
            return await _context.Help.ToListAsync();
        }

        public async Task<Help> GetHelpQueryByIdAsync(int id)
        {
            return await _context.Help.FindAsync(id);
        }

        public async Task<Help> CreateHelpQueryAsync(Help help)
        {
            _context.Help.Add(help);
            await _context.SaveChangesAsync();
            return help;
        }

        public async Task<Help> UpdateHelpQueryAsync(Help help)
        {
            _context.Help.Update(help);
            await _context.SaveChangesAsync();
            return help;
        }

        public async Task DeleteHelpQueryAsync(int id)
        {
            var help = await _context.Help.FindAsync(id);
            if (help != null)
            {
                _context.Help.Remove(help);
                await _context.SaveChangesAsync();
            }
        }
    }
}
