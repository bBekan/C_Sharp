using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ImenikAPI.ViewModels
{
    public class PersonViewModel
    {
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
        [DefaultValue(1)]
        public int CountryId { get; set; }
        [Required]
        [DefaultValue(1)]
        public int CountyId { get; set; }
    }
}
