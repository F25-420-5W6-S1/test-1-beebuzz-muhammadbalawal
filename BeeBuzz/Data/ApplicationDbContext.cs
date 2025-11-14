using BeeBuzz.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeeBuzz.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Organization> organizations { get; set; }
        public DbSet<Beehive> Beehives { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One user will have multiple bee hives
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(b => b.UserBeehive);

            //one user that is part of an organization
            //modelBuilder.Entity<ApplicationUser>()
            //   .HasOne(o => o.UserOrganization);

            //One organization can have multiple users
            modelBuilder.Entity<Organization>()
                .HasMany(u => u.OrganizationUsers);

        }
    }
}
