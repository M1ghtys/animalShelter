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
            if (_dbContext.Animal.Any())
            {
                return;
            }

            var diagnosis = AnimalsList.GetAnimals();
            foreach (var m in diagnosis)
            {
                _dbContext.Animal.Add(m);
            }

            _dbContext.SaveChanges();
        }

        public void SeedEmployees()
        {
            if (_dbContext.Employee.Any())
            {
                return;
            }

            var diagnosis = EmployeesList.GetEmployees();
            foreach (var m in diagnosis)
            {
                _dbContext.Employee.Add(m);
            }

            _dbContext.SaveChanges();
        }

        public void SeedHealthConditions()
        {
            if (_dbContext.HealthCondition.Any())
            {
                return;
            }

            var diagnosis = HealthConditionsList.GetHealthConditions();
            foreach (var m in diagnosis)
            {
                _dbContext.HealthCondition.Add(m);
            }

            _dbContext.SaveChanges();
        }

        public void SeedOccupations()
        {
            if (_dbContext.Occupation.Any())
            {
                return;
            }

            var diagnosis = OccupationsList.GetOccupations();
            foreach (var m in diagnosis)
            {
                _dbContext.Occupation.Add(m);
            }

            _dbContext.SaveChanges();
        }

        public void SeedPhotos()
        {
            if (_dbContext.Photo.Any())
            {
                return;
            }

            var diagnosis = PhotosList.GetPhotos();
            foreach (var m in diagnosis)
            {
                _dbContext.Photo.Add(m);
            }

            _dbContext.SaveChanges();
        }

        public void SeedVeterinaryRecords()
        {
            if (_dbContext.VeterinaryRecord.Any())
            {
                return;
            }

            var diagnosis = VeterinaryRecordsList.GetVeterinaryRecords();
            foreach (var m in diagnosis)
            {
                _dbContext.VeterinaryRecord.Add(m);
            }

            _dbContext.SaveChanges();
        }
        
        public void SeedVolunteers()
        {
            if (_dbContext.Volunteer.Any())
            {
                return;
            }

            var diagnosis = VolunteersList.GetVolunteers();
            foreach (var m in diagnosis)
            {
                _dbContext.Volunteer.Add(m);
            }

            _dbContext.SaveChanges();
        }

        public void SeedWalks()
        {
            if (_dbContext.Walk.Any())
            {
                return;
            }

            var diagnosis = WalksList.GetWalks();
            foreach (var m in diagnosis)
            {
                _dbContext.Walk.Add(m);
            }

            _dbContext.SaveChanges();
        }
    }
}
