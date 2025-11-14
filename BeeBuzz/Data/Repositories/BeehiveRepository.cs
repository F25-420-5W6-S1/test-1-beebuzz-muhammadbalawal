using BeeBuzz.Data.Entities;
using BeeBuzz.Data.Interfaces;

namespace BeeBuzz.Data.Repositories
{
    public class BeehiveRepository : BeeBuzzGenericGenericRepository<Beehive>, IBeehiveRepository
    {
        private readonly ILogger<BeehiveRepository> _specificLogger;

        public BeehiveRepository(
            ApplicationDbContext db,
            ILogger<BeeBuzzGenericGenericRepository<Beehive>> genericLogger,
            ILogger<BeehiveRepository> specificLogger)
            : base(db, genericLogger)
        {
            _specificLogger = specificLogger;
        }
    }
}
