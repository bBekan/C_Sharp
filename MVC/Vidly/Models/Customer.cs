using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Display(Name = "Newsletter")]
        public bool IsSubscribedToNewsletter { get; set; }
        public Membership Membership { get; set; }
        [Display(Name = "Membership Type")]
        public byte MembershipId { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate{ get; set;}

        public string GetDate()
        {
            return Birthdate.Value.ToShortDateString();
        }
    }
}
