using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace iis.Models
{
    public class Occupation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Permissions { get; set; }
        public double Pay { get; set; }
        
        
        public ICollection<Employee> Employees { get; set; } = new Collection<Employee>();
    }
}
