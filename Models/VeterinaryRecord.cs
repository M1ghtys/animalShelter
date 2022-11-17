using System;
using System.ComponentModel.DataAnnotations;

namespace iis.Models
{
    public class VeterinaryRecord
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public string Details { get; set; }
    }
}
