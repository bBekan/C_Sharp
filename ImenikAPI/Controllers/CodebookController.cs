using ImenikAPI.Models;
using ImenikAPI.ViewModels;
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
            var countries = await _context.Countries.Include(c => c.Counties).ToListAsync();
            var countriesVMList = new List<CountryViewModel>();

            foreach(var country in countries)
            {
                countriesVMList.Add(new CountryViewModel()
                {
                    Id = country.Id,
                    Name = country.Name,
                    Abbreviation = country.Abbreviation,
                    IsInEu = country.IsInEu
                });
            }

            return Ok(countriesVMList);
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

            var counties = await _context.Counties.Include(c => c.Country).ToListAsync();
            var countiesVMList = new List<CountyViewModel>();

            foreach (var county in counties)
            {
                countiesVMList.Add(new CountyViewModel()
                {
                    Id = county.Id,
                    Name = county.Name,
                    Abbreviation = county.Abbreviation,
                    AreaCode = county.AreaCode,
                    CountryId = county.CountryId
                });
            }

            return Ok(countiesVMList);
        }
    }
}
