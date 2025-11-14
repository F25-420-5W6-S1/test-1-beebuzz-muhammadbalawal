using BeeBuzz.Data.Entities;
using BeeBuzz.Data.Interfaces;

namespace BeeBuzz.Data.Repositories
{
    public class ApplicationUserRepository : BeeBuzzGenericGenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ILogger<ApplicationUserRepository> _specificLogger;

        public ApplicationUserRepository(
            ApplicationDbContext db,
            ILogger<BeeBuzzGenericGenericRepository<ApplicationUser>> genericLogger,
            ILogger<ApplicationUserRepository> specificLogger)
            : base(db, genericLogger)
        {
            _specificLogger = specificLogger;
        }

        public ICollection<ApplicationUser> GetUserByOrganizationId(int OrganizationId)
        {
            var user = _dbSet.Where(u => u.UserOrganizationId == OrganizationId).ToList();

            return user;

        }


    }
}
