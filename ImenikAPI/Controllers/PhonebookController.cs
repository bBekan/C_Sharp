using ImenikAPI.Models;
using ImenikAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ImenikAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImenikController : ControllerBase
    {
        public InMemoryDbContext _context;

        public ImenikController(InMemoryDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all users 
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAllUsers")]
        [Authorize(Roles = Roles.User + "," + Roles.Admin)]
        public IActionResult Get()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            return Ok(_context.Users);
        }

        /// <summary>
        /// Retrieves User by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetUserById")]
        [Authorize(Roles = Roles.User + "," + Roles.Admin)]
        public IActionResult Get(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        /// <summary>
        /// Add a new user
        /// </summary>
        /// <param name="user"></param>
        [HttpPost( Name = "AddUser")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> AddAsync([FromBody] PersonViewModel user)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var country = await _context.Countries.Include(c => c.Counties).SingleOrDefaultAsync(c => c.Id == user.CountryId);
            if (country == null) return NotFound("There is no country with id " + user.CountryId);

            var county = country.Counties.SingleOrDefault(c => c.Id == user.CountyId);
            if (county == null) return NotFound("There is no county with id " + user.CountyId);

            var newUser = new Person()
            {
                Id = _context.Users.Count() == 0 ? 1 : _context.Users.Last().Id + 1,
                Name = user.Name,
                Surname = user.Surname,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                DOB = user.DOB,
                City = user.City,
                StreetName = user.StreetName,
                County = county,
                Country = country,
                CountyId = user.CountyId,
                CountryId = user.CountryId

            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return Ok(user);
        }
        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> EditAsync(int id, PersonViewModel user)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var oldUser = _context.Users.SingleOrDefault(u => u.Id == id);
            if (oldUser == null) return NotFound("There is no user with id " + id);

            var country = await _context.Countries.Include(c => c.Counties).SingleOrDefaultAsync(c => c.Id == user.CountryId);
            if (country == null) return NotFound("There is no country with id " + user.CountryId);

            var county = country.Counties.SingleOrDefault(c => c.Id == user.CountyId);
            if (county == null) return NotFound("There is no county with id " + user.CountyId);

            if (ModelState.IsValid)
            {
                oldUser.Name = user.Name;
                oldUser.Surname = user.Surname;
                oldUser.PhoneNumber = user.PhoneNumber;
                oldUser.StreetName = user.StreetName;
                oldUser.City = user.City;
                oldUser.DOB = user.DOB;
                oldUser.Email = user.Email;
                oldUser.CountryId = user.CountryId;
                oldUser.Country = country;
                oldUser.CountyId = user.CountyId;
                oldUser.County = county;

            }
            _context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteUser")]
        [Authorize(Roles = Roles.Admin)]
        public IActionResult Delete(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            Person user = _context.Users.SingleOrDefault(u => u.Id == id);
            if(user == null)
            {
                return NotFound();
            }
            _context.Remove(user);
            _context.SaveChanges();
            return Ok();
        }
    }
}
