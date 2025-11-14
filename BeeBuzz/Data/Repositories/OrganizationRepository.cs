using BeeBuzz.Data.Entities;
using BeeBuzz.Data.Interfaces;
using Microsoft.Extensions.Logging;

namespace BeeBuzz.Data.Repositories
{
    public class OrganizationRepository : BeeBuzzGenericGenericRepository<Organization>, IOrganizationRepository
    {
        private readonly ILogger<OrganizationRepository> _specificLogger;

        public OrganizationRepository(
            ApplicationDbContext db,
            ILogger<BeeBuzzGenericGenericRepository<Organization>> genericLogger,
            ILogger<OrganizationRepository> specificLogger)
            : base(db, genericLogger)
        {
            _specificLogger = specificLogger;
        }

        //public ICollection<Beehive> GetBeehiveByOrganizationId(int OrganizationId)
        //{
        //    var Behive = _dbSet.Where(o => o.OrganizationId == OrganizationId).ToList();

        //    return Behive;
        //}
    }
}
