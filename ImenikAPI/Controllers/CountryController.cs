using ImenikAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImenikAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        public InMemoryDbContext _context;

        public CountryController(InMemoryDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// List all countries
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "Get Country")]
        public async Task<IEnumerable<Country>> GetAsync()
        {
            var countries = await _context.Countries.Include(c => c.Counties).ToListAsync();
            return countries;
        }
    }
}

