using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ImenikAPI.Models
{
    public class County
    {
        public int Id { get; set; }
        [Required]
        [StringLength(64)]
        public string Name { get; set; }
        [Required]
        [StringLength(4)]
        public string Abbreviation { get; set; }
        [Required]
        [Display(Name = "Area code")]
        [StringLength(16)]
        public string AreaCode { get; set; }
        [JsonIgnore]
        public Country Country { get; set; }
        [Required]
        public int CountryId { get; set; }
        [JsonIgnore]
        public List<Person> Residents { get; set; }
        [JsonIgnore]
        public List<AdditionalData> AdditionalData { get; set; }

        public County()
        {
            Residents = new List<Person>();
            AdditionalData = new List<AdditionalData>();
        }
    }
}
