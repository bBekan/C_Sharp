using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ImenikAPI.ViewModels
{
    public class PersonViewModel
    {
        [Required]
        [StringLength(64)]
        [DefaultValue("")]
        public string Name { get; set; }
        [Required]
        [StringLength(64)]
        [DefaultValue("")]
        public string Surname { get; set; }
        [Required]
        [StringLength(16)]
        [DefaultValue("")]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(64)]
        [DefaultValue("")]
        public string Email { get; set; }
        [Required]
        [DefaultValue("YYYY-mm-dd")]
        public DateOnly DOB { get; set; }
        [Required]
        [StringLength(64)]
        [DefaultValue("")]
        public string City { get; set; }
        [Required]
        [StringLength(64)]
        [DefaultValue("")]
        public string StreetName { get; set; }
        [Required]
        [DefaultValue(1)]
        public int CountryId { get; set; }
        [Required]
        [DefaultValue(1)]
        public int CountyId { get; set; }
    }
}
