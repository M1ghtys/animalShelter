using System;
using System.ComponentModel.DataAnnotations;

namespace iis.Models
{
    public class Volunteer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Verified { get; set; }
        public string Comment { get; set; }
    }
}
