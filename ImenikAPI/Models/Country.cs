using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ImenikAPI.Models
{
    public class Country
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
        [DefaultValue("EU?")]
        public string IsInEu { get; set; }
        [JsonIgnore]
        public List<County> Counties { get; set; }
        [JsonIgnore]
        public List<Person> Citizens { get; set; }
        [JsonIgnore]
        public List<AdditionalData> AdditionalData { get; set; }

        public Country()
        {
            Counties = new List<County>();
            Citizens = new List<Person>();
            AdditionalData = new List<AdditionalData>();
        }


        internal bool HasCounty(int? countyId)
        {
            if (countyId == null) return false;
            if (Counties.SingleOrDefault(c => c.Id == countyId) == null) return false;
            return true;
        }
    }
}
