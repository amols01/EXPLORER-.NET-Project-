using Bhatkanti_.Data;
using Bhatkanti_.Models;
using Bhatkanti_.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bhatkanti_.ServicesImpl
{
    public class LocationServiceImpl : ILocationService
    {
        private readonly TravelGuideContext _context;

        public LocationServiceImpl(TravelGuideContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            return await _context.Locations.Include(l => l.City).ToListAsync();
        }

        public async Task<IEnumerable<Location>> GetLocationsByCityNameAsync(string cityName)
        {
            return await _context.Locations
                .Include(l => l.City)
                .Where(l => l.City.CityName == cityName)
                .ToListAsync();
        }

        public async Task<Location> GetLocationByLocationNameAsync(string locationName)
        {
            return await _context.Locations
                .Include(l => l.City)
                .FirstOrDefaultAsync(l => l.PlaceName == locationName);
        }

        public async Task<Location> AddLocationAsync(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<bool> UpdateLocationAsync(int id, Location location)
        {
            if (id != location.PlaceId)
            {
                return false;
            }

            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await LocationExistsAsync(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<bool> DeleteLocationAsync(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return false;
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> LocationExistsAsync(int id)
        {
            return await _context.Locations.AnyAsync(e => e.PlaceId == id);
        }
    }
}
