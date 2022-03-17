using ImenikAPI.Models;
using ImenikAPI.ViewModels;
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
        public async Task<IActionResult> GetAsync(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
            if (user == null) return NotFound("There is no user with id " + id);

            var data = await _context.AdditionalData.SingleOrDefaultAsync(u => u.UserId == id);
            if (data == null) return NotFound("User has no additional data");
            return Ok(data);
        }
        /// <summary>
        /// Add user additional data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="additionalData"></param>
        /// <returns></returns>
        [HttpPost("{id}")]
        public async Task<IActionResult> PostAsync(int id, AdditionalDataViewModel additionalData)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
            if (user == null) return NotFound("There is no user with id " + id);

            if(additionalData.CountryId != 0 && additionalData.CountyId == 0 || additionalData.CountryId == 0 && additionalData.CountyId != 0)
            {
                return NotFound("Either CountyId or CountryId was not set");
            }

            Country? country = null;
            if (additionalData.CountryId != 0)
            {
                country = await _context.Countries.Include(c => c.Counties).SingleOrDefaultAsync(c => c.Id == additionalData.CountryId);
                if (country == null) return NotFound("There is no country with id " + additionalData.CountryId);
            }

            if(country != null)
            {
                if (!country.HasCounty(additionalData.CountyId)) return NotFound(country.Name + " does not contain county of id " + additionalData.CountyId);
            }

            County county = await _context.Counties.SingleOrDefaultAsync(c => c.Id == additionalData.CountyId); 

            var data = new AdditionalData()
            {
                Id = _context.AdditionalData.Count() + 1,
                City = additionalData.City,
                Street = additionalData.Street,
                HouseNumber = additionalData.HouseNumber,
                PhoneNumber = additionalData.PhoneNumber,
                Email = additionalData.Email,
                CountyId = additionalData.CountyId,
                CountryId = additionalData.CountryId,
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
        public async Task<IActionResult> EditAsync(int id, AdditionalDataViewModel additionalData)
        {
            var user = await _context.AdditionalData.SingleOrDefaultAsync(d => d.UserId == id);
            if (user == null) return NotFound("There is no additional data of user with id " + id);
            Country? country = null;

            if (additionalData.CountryId != user.CountryId)
            {
                country = await _context.Countries.Include(c => c.Counties).SingleOrDefaultAsync(c => c.Id == additionalData.CountryId);

                if (country == null) 
                    return NotFound("There is no country with id " + additionalData.CountryId);

                if (!country.HasCounty(additionalData.CountyId) && !country.HasCounty(user.CountyId))
                    return NotFound("County with id " + additionalData.CountyId + " is not located in " + country.Name);
            }
            else if(additionalData.CountryId == 0 && additionalData.CountyId != 0)
            {
                return NotFound("The countryId must also be updated to update the countyId");
            }
            else
            {
                var oldCountry = await _context.Countries.Include(c => c.Counties).SingleAsync(c => c.Id == user.CountryId);
                if (!oldCountry.HasCounty(additionalData.CountyId))
                    return NotFound(user.Country.Name + " does not contain county with id " + additionalData.CountyId);
            }



            County? county = null;
            if (additionalData.CountyId != 0)
            {
                county = await _context.Counties.SingleOrDefaultAsync(c => c.Id == additionalData.CountyId);
                if (county == null) return NotFound("There is no county with id " + additionalData.CountyId);
            }


            if (ModelState.IsValid)
            {
                user.City = additionalData.City;
                user.Street = additionalData.Street;
                user.HouseNumber = additionalData.HouseNumber;
                user.PhoneNumber = additionalData.PhoneNumber;
                user.Email = additionalData.Email;
                user.CountyId = additionalData.CountyId;
                user.CountryId = additionalData.CountryId;
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
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
            if (user == null) return NotFound("There is no user with id " + id);

            _context.Remove(user);
            _context.SaveChanges();

            return Ok();
        }

    }
}
