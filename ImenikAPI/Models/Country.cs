using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ImenikAPI.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        [StringLength(64)]
        public string Name { get; set; }
        [Required]
        [StringLength(4)]
        public string Abbreviation { get; set; }
        [Required]
        public string IsInEu { get; set; }
        public List<County> Counties { get; set; }
        public List<Person> Citizens { get; set; }
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
