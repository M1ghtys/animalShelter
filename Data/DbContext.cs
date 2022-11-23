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