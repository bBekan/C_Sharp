#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    [Authorize]
    public class RentalsController : Controller
    {
        private readonly VidlyContext _context;

        public RentalsController(VidlyContext context)
        {
            _context = context;
        }


        // GET: Rentals/Create
        public IActionResult Create()
        {
            var rental = new CustomerMovieRental()
            {
                Customers = _context.Customer.ToList(),
                Movies = _context.Movie.ToList(),
                Rentals = _context.Rentals.ToList()
            };
            return View(rental);
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int CustomerId, int MovieId)
        {
            var newRental = new Rental()
            {
                DateRented = DateTime.Now,
                Movie = _context.Movie.SingleOrDefault(m => m.Id == MovieId),
                Customer = _context.Customer.SingleOrDefault(c => c.Id == CustomerId),
            };
            if (ModelState.IsValid)
            {
                _context.Add(newRental);
                _context.Movie.Where(m => m.Id == MovieId).ToList().ForEach(m => m.NumberAvailable--);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            var oldRental = new CustomerMovieRental()
            {
                Customers = _context.Customer.ToList(),
                Movies = _context.Movie.ToList(),
                MovieId = MovieId,
                CustomerId = CustomerId,
                Rentals = _context.Rentals.ToList()
            };
            return View(oldRental);
        }
    }

}
