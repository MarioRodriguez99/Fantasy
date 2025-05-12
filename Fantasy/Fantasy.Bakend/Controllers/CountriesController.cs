using Fantasy.Bakend.Data;
using Fantasy.Shared.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fantasy.Bakend.Controllers //https://localhost:7113/
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly FantasyContext _context;

        public CountriesController(FantasyContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Country country)
        {
            var correntContries = await _context.Countries.FindAsync(country.Id);
            if (correntContries == null)
            {
                return NotFound();
            }
            correntContries.Name = country.Name;
            _context.Update(correntContries);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var contries = await _context.Countries.FindAsync(id);
            if (contries == null)
            {
                return NotFound();
            }

            _context.Remove(contries);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}