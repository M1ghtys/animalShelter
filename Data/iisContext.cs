using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using iis.Models;

namespace iis.Data
{
    public class iisContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<iis.Models.Animal> Animal { get; set; }
        public DbSet<iis.Models.Volunteer> Volunteer { get; set; }
        public DbSet<iis.Models.Walk> Walk { get; set; }
    }
}
