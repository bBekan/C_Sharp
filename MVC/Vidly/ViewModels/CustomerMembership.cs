using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerMembership
    {
        public Customer Customer { get; set; }
        public IEnumerable<Membership> Memberships { get; set; }
    }
}
