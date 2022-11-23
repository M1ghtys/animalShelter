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
