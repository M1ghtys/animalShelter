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
            var AdminId = "92b2f5f0-84f0-44cb-a760-9bfcc215c63a";

            if (_dbContext.Users.Any(a => a.Id == AdminId)) return;

            var admin = new Models.User
            {
                Id = AdminId,
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

        public void SeedUser()
        {

            var listUU = UserList.GetUnverifiedUsers();
            foreach (var x in listUU)
            {
                if (!_dbContext.Users.Any(a => a.Id == x.Id))
                {
                    _dbContext.Users.Add(x);
                    var result = _userManager.CreateAsync(x, "useruser").Result;
                    if (result.Succeeded)
                    {
                        result = _userManager.AddToRoleAsync(x, Roles.GetRoles()[Role.UnverifiedUser]).Result;
                    }

                    if (!result.Succeeded)
                    {
                        throw new InvalidOperationException("Initial db with UnverifiedUser failed");
                    }
                }
            }

            var listVU = UserList.GetVerifiedUsers();
            foreach (var x in listVU)
            {
                if (!_dbContext.Users.Any(a => a.Id == x.Id))
                {
                    _dbContext.Users.Add(x);
                    var result = _userManager.CreateAsync(x, "useruser").Result;
                    if (result.Succeeded)
                    {
                        result = _userManager.AddToRoleAsync(x, Roles.GetRoles()[Role.VerifiedUser]).Result;
                    }
                    if (!result.Succeeded)
                    {
                        throw new InvalidOperationException("Initial db with VerifiedUser failed");
                    }
                }
            }

            var listV = UserList.GetVets();
            foreach (var x in listV)
            {
                if (!_dbContext.Users.Any(a => a.Id == x.Id))
                {
                    _dbContext.Users.Add(x);
                    var result = _userManager.CreateAsync(x, "useruser").Result;
                    if (result.Succeeded)
                    {
                        result = _userManager.AddToRoleAsync(x, Roles.GetRoles()[Role.Vet]).Result;
                    }
                    if (!result.Succeeded)
                    {
                        throw new InvalidOperationException("Initial db with Vet failed");
                    }
                }
            }

            var listCT = UserList.GetCareTakers();
            foreach (var x in listCT)
            {
                if (!_dbContext.Users.Any(a => a.Id == x.Id))
                {
                    _dbContext.Users.Add(x);
                    var result = _userManager.CreateAsync(x, "useruser").Result;
                    if (result.Succeeded)
                    {
                        result = _userManager.AddToRoleAsync(x, Roles.GetRoles()[Role.Caretaker]).Result;
                    }
                    if (!result.Succeeded)
                    {
                        throw new InvalidOperationException("Initial db with Caretaker failed");
                    }
                }
            }

            _dbContext.SaveChanges();
        }

        public void SeedAnimals()
        {
            var list = AnimalsList.GetAnimals();
            foreach (var x in list)
            {
                if (!_dbContext.Animal.Any(a => a.Id == x.Id))
                {
                    _dbContext.Animal.Add(x);
                }
            }
            _dbContext.SaveChanges();
        }
        
        public void SeedPhotos()
        {
            var list = PhotosList.GetPhotos();
            foreach (var x in list)
            {
                if (!_dbContext.Photo.Any(a => a.Id == x.Id))
                {
                    _dbContext.Photo.Add(x);
                }
            }
            _dbContext.SaveChanges();
        }

        public void SeedVeterinaryRecords()
        {
            var list = VeterinaryRecordsList.GetVeterinaryRecords();
            foreach (var x in list)
            {
                if (!_dbContext.VeterinaryRecord.Any(a => a.Id == x.Id))
                {
                    _dbContext.VeterinaryRecord.Add(x);
                }
            }
            _dbContext.SaveChanges();
        }

        public void SeedWalks()
        {
            var list = WalksList.GetWalks();
            foreach (var x in list)
            {
                if (!_dbContext.Walk.Any(a => a.Id == x.Id))
                {
                    _dbContext.Walk.Add(x);
                }
            }
            _dbContext.SaveChanges();
        }
    }
}
