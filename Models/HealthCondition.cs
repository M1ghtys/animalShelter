using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iis.Models
{
    public class HealthCondition
    {
        [Required]
        [Key]
        public int AnimalId { get; set; }
        public bool Tattoo { get; set; }
        public bool Castration { get; set; }
        public bool Vaccinated { get; set; }
        public bool Handicapped { get; set; }
        public string Others { get; set; }
    }
}
