using Bhatkanti_.Models;
using Bhatkanti_.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bhatkanti_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        // GET: api/Location
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            return Ok(await _locationService.GetLocationsAsync());
        }

        // GET: api/Location/cityname/{cityName}
        [HttpGet("cityname/{cityName}")]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocationsByCityName(string cityName)
        {
            var locations = await _locationService.GetLocationsByCityNameAsync(cityName);

            if (locations == null || !locations.Any())
            {
                return NotFound();
            }

            return Ok(locations);
        }

        // GET: api/Location/locationname/{locationName}
        [HttpGet("locationname/{placeName}")]
        public async Task<ActionResult<Location>> GetLocationByLocationName(string placeName)
        {
            var location = await _locationService.GetLocationByLocationNameAsync(placeName);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        // POST: api/Location
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location location)
        {
            var addedLocation = await _locationService.AddLocationAsync(location);
            return CreatedAtAction(nameof(GetLocationByLocationName), new { locationName = addedLocation.PlaceName }, addedLocation);
        }

        // PUT: api/Location/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, Location location)
        {
            var isUpdated = await _locationService.UpdateLocationAsync(id, location);

            if (!isUpdated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Location/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var isDeleted = await _locationService.DeleteLocationAsync(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
