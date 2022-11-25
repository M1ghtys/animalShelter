using Microsoft.EntityFrameworkCore;
using iis.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace iis.Data
{
    public class DbContext : IdentityDbContext<User>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HealthCondition>()
                .HasOne(h => h.Animal)
                .WithOne(a => a.HealthCondition);
            modelBuilder.Entity<Photo>()
                .HasOne(p => p.Animal)
                .WithMany(a => a.Photos);
            
            modelBuilder.Entity<Walk>()
                .HasOne(w => w.Animal)
                .WithMany(a => a.Walks);
            modelBuilder.Entity<Walk>()
                .HasOne(w => w.Volunteer)
                .WithMany(v => v.Walks);
            
            modelBuilder.Entity<VeterinaryRecord>()
                .HasOne(v => v.Animal)
                .WithMany(a => a.VeterinaryRecords);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Occupation)
                .WithMany(o => o.Employees);
        }

        public DbSet<Animal> Animal { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<HealthCondition> HealthCondition { get; set; }
        public DbSet<Occupation> Occupation { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<VeterinaryRecord> VeterinaryRecord { get; set; }
        public DbSet<Volunteer> Volunteer { get; set; }
        public DbSet<Walk> Walk { get; set; }
    }
}
