using BeeBuzz.Data.Entities;

namespace BeeBuzz.Data.Interfaces
{
    public interface IOrganizationRepository : IBeeBuzzGenericRepository<Organization>
    {
        //ICollection<Beehive> GetBeehiveByOrganizationId(int OrganizationId);

    }
}
