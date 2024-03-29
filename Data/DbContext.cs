﻿using Microsoft.EntityFrameworkCore;
using iis.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace iis.Data
{
    public class DbContext : IdentityDbContext<User>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Photo>()
                .HasOne(p => p.Animal)
                .WithMany(a => a.Photos);
            
            modelBuilder.Entity<Walk>()
                .HasOne(w => w.Animal)
                .WithMany(a => a.Walks);
            modelBuilder.Entity<Walk>()
                .HasOne(w => w.User)
                .WithMany(u => u.Walks);

            modelBuilder.Entity<VeterinaryRecord>()
                .HasOne(v => v.Animal)
                .WithMany(a => a.VeterinaryRecords);
        }

        public DbSet<Animal> Animal { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<VeterinaryRecord> VeterinaryRecord { get; set; }
        public DbSet<Walk> Walk { get; set; }
    }
}
