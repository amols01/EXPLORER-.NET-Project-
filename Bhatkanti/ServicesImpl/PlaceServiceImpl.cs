using Bhatkanti.Models;
using Bhatkanti.Services;
using Microsoft.EntityFrameworkCore;

namespace Bhatkanti.ServicesImpl
{
    public class PlaceServiceImpl : IPlaceService
    {
        private readonly ApplicationDbContext _context;

        public PlaceServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Place>> GetLocationsByCityAsync(int cityId)
        {
            var locations = await _context.Places
                .Where(l => l.City_ID == cityId)
                .ToListAsync();
            return locations;
        }
        public async Task<IEnumerable<Place>> GetAllPlacesAsync()
        {
            return await _context.Places.ToListAsync();
        }

        public async Task<Place> GetPlaceByIdAsync(int id)
        {
            return await _context.Places.FindAsync(id);
        }

        public async Task<Place> CreatePlaceAsync(Place place)
        {
            _context.Places.Add(place);
            await _context.SaveChangesAsync();
            return place;
        }

        public async Task<Place> UpdatePlaceAsync(Place place)
        {
            _context.Places.Update(place);
            await _context.SaveChangesAsync();
            return place;
        }

        public async Task DeletePlaceAsync(int id)
        {
            var place = await _context.Places.FindAsync(id);
            if (place != null)
            {
                _context.Places.Remove(place);
                await _context.SaveChangesAsync();
            }
        }
        }
}
