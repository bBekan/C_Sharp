using ImenikAPI.Models;
using ImenikAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImenikAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdditionalDataController : ControllerBase
    {
        public InMemoryDbContext _context;

        public AdditionalDataController(InMemoryDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get user additional data
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Roles = Roles.User + "," + Roles.Admin)]
        public async Task<IActionResult> GetAsync(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
            if (user == null) 
                return NotFound("There is no user with id " + id);

            var data = await _context.AdditionalData.SingleOrDefaultAsync(u => u.UserId == id);
            if (data == null) 
                return NotFound("User has no additional data");

            return Ok(data);
        }

        /// <summary>
        /// Add user additional data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="additionalData"></param>
        /// <returns></returns>
        [HttpPost("{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> PostAsync(int id, AdditionalDataViewModel additionalData)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var hasData = _context.AdditionalData
                .SingleOrDefault(u => u.UserId == id);

            if (hasData != null)
                return Problem("This user already has additional data which can only be edited using the edit form");

            var user = await _context.Users
                .SingleOrDefaultAsync(u => u.Id == id);

            if (user == null) return NotFound("There is no user with id " + id);

            var countryId = additionalData.CountryId;
            var countyId = additionalData.CountyId;

            var country = _context.Countries
                .Include(c => c.Counties)
                .SingleOrDefault(c => c.Id == countryId);

            if (country == null && countryId != null)
                return NotFound("There is no country with id " + countryId);

            if (countyId != null && countryId != null && !country.HasCounty(countyId))
                return NotFound(country.Name + " doesn't contain a county with id " + id);

            if (countryId == 0 && countyId != 0)
                return Problem("CountryId must be set when setting countyId");

            var county = _context.Counties
                .SingleOrDefault(c => c.Id == countyId);

            var data = new AdditionalData()
            {
                Id = _context.AdditionalData.Count() + 1,
                City = additionalData.City,
                Street = additionalData.Street,
                HouseNumber = additionalData.HouseNumber,
                PhoneNumber = additionalData.PhoneNumber,
                Email = additionalData.Email,
                CountyId = countyId,
                CountryId = countryId,
                UserId = id,
                Person = user,
                Country = country,
                County = county
            };
            _context.Add(data);
            _context.SaveChanges();
            return Ok(data);
        }

        /// <summary>
        /// Edit a users additional data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="additionalData"></param>
        /// <returns></returns>
        [HttpPut("id")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> EditAsync(int id, AdditionalDataViewModel additionalData)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var user = await _context.AdditionalData.SingleOrDefaultAsync(d => d.UserId == id);
            if (user == null) return NotFound("There is no additional data of user with id " + id);

            var countryId = additionalData.CountryId != user.CountryId && additionalData.CountryId != null ? additionalData.CountryId : user.CountryId;
            var countyId = additionalData.CountyId != user.CountyId && additionalData.CountyId != null ? additionalData.CountyId : user.CountyId;

            var country = _context.Countries
                .Include(c => c.Counties)
                .SingleOrDefault(c => c.Id == countryId);

            if (country == null)
                return NotFound("There is no country with id " + countryId);

            if (countyId != null && !country.HasCounty(countyId))
                return NotFound(country.Name + " doesn't contain a county with id " + countyId);

            var county = _context.Counties
                .SingleOrDefault(c => c.Id == countyId);

            if (ModelState.IsValid)
            {
                user.City = additionalData.City;
                user.Street = additionalData.Street;
                user.HouseNumber = additionalData.HouseNumber;
                user.PhoneNumber = additionalData.PhoneNumber;
                user.Email = additionalData.Email;
                user.CountyId = countyId;
                user.CountryId = countryId;
                user.UserId = id;
                user.Country = country;
                user.County = county;
            }


            _context.SaveChanges();
            return Ok(user);

        }

        /// <summary>
        /// Delete additional data from user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
            if (user == null) return NotFound("There is no user with id " + id);

            _context.Remove(user);
            _context.SaveChanges();

            return Ok("User succesfully deleted");
        }

    }
}
