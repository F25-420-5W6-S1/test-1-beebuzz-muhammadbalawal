namespace BeeBuzz.Data.Entities
{
    public class Organization
    {
        public int OrganizationId { get; set; }
        public ICollection<ApplicationUser> OrganizationUsers { get; set; }
    }
}
