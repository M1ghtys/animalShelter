using Microsoft.EntityFrameworkCore;
using iis.Data.Content;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System;

namespace iis.Data
{
    public class DbInitializer
    {
        private readonly DbContext _dbContext;
        private readonly UserManager<Models.User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(DbContext dbcontext, UserManager<iis.Models.User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbcontext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Migrate() => _dbContext.Database.Migrate();

        public void SeedRoles()
        {
            if (_dbContext.Roles.Any())
            {
                return;
            }

            var roles = Roles.GetRoles().Values;
            foreach (var role in roles)
            {
                var result = _roleManager.CreateAsync(new IdentityRole(role)).Result;
                if (!result.Succeeded)
                {
                    throw new InvalidOperationException("Initial db with roles failed");
                }
            }
        }

        public void SeedAdminUser(string password)
        {
            if (_dbContext.Users.Any())
            {
                return;
            }

            var admin = new Models.User
            {
                UserName = "admin",
                Email = "admin@example.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
            };

            var result = _userManager.CreateAsync(admin, password).Result;
            if (result.Succeeded)
            {
                result = _userManager.AddToRoleAsync(admin, Roles.GetRoles()[Role.Admin]).Result;
            }

            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Initial db with admin failed");
            }
        }

        public void SeedAnimals()
        {
            _dbContext.Animal.AddRange(AnimalsList.GetAnimals());
            _dbContext.SaveChanges();
        }

        public void SeedEmployees()
        {
            _dbContext.Employee.AddRange(EmployeesList.GetEmployees());
            _dbContext.SaveChanges();
        }

        public void SeedHealthConditions()
        {
            _dbContext.HealthCondition.AddRange(HealthConditionsList.GetHealthConditions());
            _dbContext.SaveChanges();
        }

        public void SeedOccupations()
        {
            _dbContext.Occupation.AddRange(OccupationsList.GetOccupations());
            _dbContext.SaveChanges();
        }

        public void SeedPhotos()
        {
            _dbContext.Photo.AddRange(PhotosList.GetPhotos());
            _dbContext.SaveChanges();
        }

        public void SeedVeterinaryRecords()
        {
            _dbContext.VeterinaryRecord.AddRange(VeterinaryRecordsList.GetVeterinaryRecords());
            _dbContext.SaveChanges();
        }
        
        public void SeedVolunteers()
        {
            _dbContext.Volunteer.AddRange(VolunteersList.GetVolunteers());
            _dbContext.SaveChanges();
        }

        public void SeedWalks()
        {
            _dbContext.Walk.AddRange(WalksList.GetWalks());
            _dbContext.SaveChanges();
        }
    }
}
