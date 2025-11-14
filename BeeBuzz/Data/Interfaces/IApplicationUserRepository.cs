using BeeBuzz.Data.Entities;

namespace BeeBuzz.Data.Interfaces
{
    public interface IApplicationUserRepository
    {
        ICollection<ApplicationUser> GetUserByOrganizationId(int OrganizationId);
    }
}
