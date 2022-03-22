using System.ComponentModel;
using System.Text.Json.Serialization;

namespace ImenikAPI.Models
{
    public class AdditionalData
    {
        public int Id { get; set; }
        [DefaultValue("City")]
        public string? City { get; set; }
        [DefaultValue("Street")]
        public string? Street { get; set; }
        [DefaultValue("House number")]
        public string? HouseNumber { get; set; }
        [DefaultValue("Phone number")]
        public string? PhoneNumber { get; set; }
        [DefaultValue("Email")]
        public string? Email { get; set; }
        [DefaultValue("CountyId")]
        public int? CountyId { get; set; }
        [JsonIgnore]   
        public County? County { get; set; }
        [DefaultValue("CountryId")]
        public int? CountryId { get; set; }
        [JsonIgnore]
        public Country? Country { get; set; }
        [DefaultValue("UserId")]
        public int? UserId { get; set; }
        [JsonIgnore]
        public Person? Person { get; set; }
    }
}
