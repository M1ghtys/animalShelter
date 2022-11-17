using System;
using System.ComponentModel.DataAnnotations;

namespace iis.Models
{
    public class Occupation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Permissions { get; set; }
        public double Pay { get; set; }
    }
}
