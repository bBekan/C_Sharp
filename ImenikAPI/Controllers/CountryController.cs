using ImenikAPI.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<Country> Get()
        {
            var countries = _context.Countries.ToArray();
            return countries;
        }
    }
}

