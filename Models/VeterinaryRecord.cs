using System;
using System.ComponentModel.DataAnnotations;

namespace iis.Models
{
    public class VeterinaryRecord
    {
        public Guid Id { get; set; }
        public Guid AnimalId { get; set; }
        public Animal? Animal  { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public string Details { get; set; }
    }
}
