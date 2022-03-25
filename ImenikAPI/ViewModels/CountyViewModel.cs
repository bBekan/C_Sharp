using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ImenikAPI.ViewModels
{
    public class CountyViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(64)]
        public string Name { get; set; }
        [Required]
        [StringLength(4)]
        public string Abbreviation { get; set; }
        [Required]
        [StringLength(16)]
        public string AreaCode { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}
