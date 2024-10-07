using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bhatkanti_.Data;
using Bhatkanti_.Models;

namespace Bhatkanti_.Services
{
    public class CityService : ICityService
    {
        private readonly TravelGuideContext _context;

        public CityService(TravelGuideContext context)
        {
            _context = context;
        }

        public async Task<City> GetCityByIdAsync(int cityId)
        {
            return await _context.Cities.FindAsync(cityId);
        }

        public async Task<City> AddCityAsync(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task<City> UpdateCityAsync(City city)
        {
            _context.Entry(city).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task<bool> DeleteCityAsync(int cityId)
        {
            var city = await _context.Cities.FindAsync(cityId);
            if (city == null)
            {
                return false;
            }

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<City>> GetAllCitiesAsync()
        {
            return await _context.Cities.ToListAsync();
        }
    }
}
