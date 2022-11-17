using System;
using System.ComponentModel.DataAnnotations;

namespace iis.Models
{
    public class Volunteer : Person
    {
        public bool Verified { get; set; }
        public string Comment { get; set; }
    }
}
