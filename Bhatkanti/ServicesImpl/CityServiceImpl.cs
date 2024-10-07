using Bhatkanti.Models;
using Bhatkanti.Services;
using Microsoft.EntityFrameworkCore;

namespace Bhatkanti.ServicesImpl
{
    public class CityServiceImpl : ICityService
    {
        private readonly ApplicationDbContext _context;

        public CityServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cities>> GetAllCitiesAsync()
        {
            return await _context.City.ToListAsync();
        }

        public async Task<Cities> GetCityByIdAsync(int id)
        {
            return await _context.City.FindAsync(id);
        }

        public async Task<Cities> CreateCityAsync(Cities city)
        {
            _context.City.Add(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task<Cities> UpdateCityAsync(Cities city)
        {
            _context.City.Update(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task DeleteCityAsync(int id)
        {
            var city = await _context.City.FindAsync(id);
            if (city != null)
            {
                _context.City.Remove(city);
                await _context.SaveChangesAsync();
            }
        }
    }
}
