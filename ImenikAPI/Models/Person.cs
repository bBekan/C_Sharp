

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ImenikAPI.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [StringLength(64)]
        public string Name { get; set; }
        [Required]
        [StringLength(64)]
        public string Surname { get; set; }
        [Required]
        [StringLength(16)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(64)]
        public string Email { get; set; }
        [Required]
        public DateOnly DOB { get; set; }
        [Required]
        [StringLength(64)]
        public string City { get; set; }
        [Required]
        [Display(Name = "Street name")]
        [StringLength(64)]
        public string StreetName { get; set; }
        [Required]
        [JsonIgnore]
        public County County { get; set; }
        [Required]
        [JsonIgnore]
        public Country Country { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required]
        public int CountyId { get; set; }

    }
}
