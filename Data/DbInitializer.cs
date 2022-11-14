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
    }
}
