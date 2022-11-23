using System;
using System.ComponentModel.DataAnnotations;

namespace iis.Models
{
    public class Volunteer : User
    {   
        public bool Verified { get; set; }
        public string Comment { get; set; }
    }
}
