using ImenikAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImenikAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountyController : ControllerBase
    {
        public InMemoryDbContext _context;

        public CountyController(InMemoryDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// List all counties
        /// </summary>
        /// <returns></returns>

        [HttpGet(Name = "GetCounty")]
        public IEnumerable<County> Get()
        {
            return _context.Counties.ToArray();
        }
    }
}
