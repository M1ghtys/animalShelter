using Microsoft.EntityFrameworkCore;
using iis.Data.Content;
using System.Linq;

namespace iis.Data
{
    public class DbInitializer
    {
        private readonly iisContext _dbContext;

        public DbInitializer(iisContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public void Migrate() => _dbContext.Database.Migrate();

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
