using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ImenikAPI.ViewModels
{
    public class CountryViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(64)]
        public string Name { get; set; }
        [Required]
        [StringLength(4)]
        public string Abbreviation { get; set; }
        [Required]
        [JsonProperty("EU_Member")]
        public string IsInEu { get; set; }
    }
}
