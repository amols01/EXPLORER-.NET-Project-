using Bhatkanti_.Data;
using Bhatkanti_.Models;
using Bhatkanti_.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bhatkanti_.ServicesImpl
{
    public class GuideVerificationService : IGuideVerificationService
    {
        private readonly TravelGuideContext _context;

        public GuideVerificationService(TravelGuideContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateVerificationAsync(GuideVerification verification)
        {
            _context.GuideVerifications.Add(verification);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<GuideVerification?> GetVerificationByIdAsync(string aadharNumber)
        {
            return await _context.GuideVerifications
                .Include(v => v.Guide)
                .FirstOrDefaultAsync(v => v.AadharNumber == aadharNumber);
        }

        public async Task<IEnumerable<GuideVerification>> GetAllVerificationsAsync()
        {
            return await _context.GuideVerifications
                .Include(v => v.Guide)
                .ToListAsync();
        }

        public async Task<bool> UpdateVerificationAsync(GuideVerification verification)
        {
            _context.GuideVerifications.Update(verification);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteVerificationAsync(string aadharNumber)
        {
            var verification = await _context.GuideVerifications.FindAsync(aadharNumber);
            if (verification == null)
            {
                return false;
            }

            _context.GuideVerifications.Remove(verification);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
