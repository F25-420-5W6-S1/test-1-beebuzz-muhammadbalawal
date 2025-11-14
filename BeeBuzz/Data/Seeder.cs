using BeeBuzz.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Text.Json;

namespace BeeBuzz.Data
{
    public enum Role
    {
        Admin,
        Default
    }

    public class Seeder
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hosting;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public Seeder(ApplicationDbContext context,
        IWebHostEnvironment hosting,
        RoleManager<IdentityRole<int>> roleManager)
        {
            _db = context;
            _hosting = hosting;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            _db.Database.EnsureCreated();



            // Add roles
            if (!_roleManager.Roles.Any())
                foreach (Role role in Enum.GetValues<Role>())
                    if (!await _roleManager.RoleExistsAsync(role.ToString()))
                        await _roleManager.CreateAsync(new IdentityRole<int>(role.ToString()));

            if (_db.Users.Any()) return;


            string baseDirectory = "Data/Mock";

            _db.Beehives.AddRange(GetObjects<Beehive>($"{baseDirectory}/users.json"));
            _db.SaveChanges();

            _db.organizations.AddRange(GetObjects<Organization>($"{baseDirectory}/users.json"));
            _db.SaveChanges();

        }

        private IEnumerable<T> GetObjects<T>(string path)
        {
            // Get hackathons
            var seederFile = Path.Combine(_hosting.ContentRootPath, path);

            if (!File.Exists(seederFile))
                throw new FileNotFoundException($"File not found: {seederFile}");

            var json = File.ReadAllText(seederFile);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<IEnumerable<T>>(json, options);
        }
    }
}
