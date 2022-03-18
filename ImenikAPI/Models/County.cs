using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ImenikAPI.Models
{
    public class County
    {
        [DefaultValue("Id")]
        public int Id { get; set; }
        [Required]
        [StringLength(64)]
        [DefaultValue("Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(4)]
        [DefaultValue("Abbreviation")]
        public string Abbreviation { get; set; }
        [Required]
        [StringLength(16)]
        [DefaultValue("Area code")]
        public string AreaCode { get; set; }
        [JsonIgnore]
        public Country Country { get; set; }
        [Required]
        [DefaultValue("CountryId")]
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
