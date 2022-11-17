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
