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
        [JsonIgnore]
        public List<County>? Counties { get; set; }
        [JsonIgnore]
        public List<Person>? Citizens { get; set; }

        public Country()
        {
            Counties = new List<County>();
            Citizens = new List<Person>();
        }
    }
}
