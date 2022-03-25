using ImenikAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImenikAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CodebookController : ControllerBase
    {
        public InMemoryDbContext _context;

        public CodebookController(InMemoryDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// List all countries
        /// </summary>
        /// <returns></returns>

        [HttpGet("countries")]
        [Authorize(Roles = Roles.User + "," + Roles.Admin)]
        public async Task<IActionResult> GetCountriesAsync()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            return Ok(await _context.Countries.Include(c => c.Counties).ToListAsync());
        }

        /// <summary>
        /// List all counties
        /// </summary>
        /// <returns></returns>
        [HttpGet("counties")]
        [Authorize(Roles = Roles.User + "," + Roles.Admin)]
        public async Task<IActionResult> GetCountiesAsync()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            return Ok(await _context.Counties.Include(c => c.Country).ToListAsync());
        }
    }
}
