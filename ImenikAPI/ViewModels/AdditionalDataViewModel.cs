using ImenikAPI.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ImenikAPI.ViewModels
{
    public class AdditionalDataViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        [DefaultValue(null)]
        public string? City { get; set; }
        [DefaultValue(null)]
        public string? Street { get; set; }
        [DefaultValue(null)]
        public string? HouseNumber { get; set; }
        [DefaultValue(null)]
        public string? PhoneNumber { get; set; }
        [DefaultValue(null)]
        public string? Email { get; set; }
        [DefaultValue(null)]
        public int? CountyId { get; set; }
        [DefaultValue(null)]
        public int? CountryId { get; set; }

        public AdditionalDataViewModel() { }
    }
}
