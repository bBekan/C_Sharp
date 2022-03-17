using System.Text.Json.Serialization;

namespace ImenikAPI.Models
{
    public class AdditionalData
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int CountyId { get; set; }
        [JsonIgnore]
        public County? County { get; set; }
        public int CountryId { get; set; }
        [JsonIgnore]
        public Country? Country { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public Person Person { get; set; }
    }
}
