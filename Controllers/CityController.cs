using Microsoft.AspNetCore.Mvc;
using Bhatkanti_.Models;
using Bhatkanti_.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bhatkanti_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            var cities = await _cityService.GetAllCitiesAsync();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            var city = await _cityService.GetCityByIdAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City city)
        {
            var createdCity = await _cityService.AddCityAsync(city);
            return CreatedAtAction(nameof(GetCity), new { id = createdCity.CityId }, createdCity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<City>> PutCity(int id, City city)
        {
            if (id != city.CityId)
            {
                return BadRequest();
            }

            var updatedCity = await _cityService.UpdateCityAsync(city);
            return Ok(updatedCity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var success = await _cityService.DeleteCityAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
