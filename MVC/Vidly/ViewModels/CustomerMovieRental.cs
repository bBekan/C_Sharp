using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerMovieRental
    {
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public  int CustomerId { get; set; }
        public IEnumerable<Rental>? Rentals { get; set; }
    }
}
