using ImenikAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ImenikAPI.ViewModels
{
    public class AdditionalDataViewModel
    {
        ///id, grad, ulica, kucni_broj, kontakt broj, email, sifarnik_zupanija_id, sifarnik_drzava_id, imenik_id.
        [JsonIgnore]
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int CountyId { get; set; }
        public int CountryId { get; set; }
    }
}
