using Microsoft.AspNetCore.Identity;

namespace BeeBuzz.Data.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public int UserOrganizationId { get; set; }
        public ICollection<Beehive> UserBeehive { get; set; }
    }
}
