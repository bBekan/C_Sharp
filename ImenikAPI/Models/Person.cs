

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ImenikAPI.Models
{
    public class Person
    {
        [DefaultValue("Id")]
        public int Id { get; set; }
        [Required]
        [StringLength(64)]
        [DefaultValue("Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(64)]
        [DefaultValue("Surname")]
        public string Surname { get; set; }
        [Required]
        [StringLength(16)]
        [DefaultValue("Phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(64)]
        [DefaultValue("Email")]
        public string Email { get; set; }
        [Required]
        [DefaultValue("2000-01-01")]
        public DateOnly DOB { get; set; }
        [Required]
        [StringLength(64)]
        [DefaultValue("City")]
        public string City { get; set; }
        [Required]
        [DefaultValue("Street")]
        [StringLength(64)]
        public string StreetName { get; set; }
        [Required]
        [JsonIgnore]
        public County County { get; set; }
        [Required]
        [JsonIgnore]
        public Country Country { get; set; }
        [Required]
        [DefaultValue("CountryId")]
        public int CountryId { get; set; }
        [Required]
        [DefaultValue("CountyId")]
        public int CountyId { get; set; }

    }
}
