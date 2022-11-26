using System;
using System.ComponentModel.DataAnnotations;

namespace iis.Models
{
    public class Photo
    {
        public Guid Id { get; set; }
        public Guid AnimalId { get; set; }
        public Animal? Animal  { get; set; }
        public string Source { get; set; }
    }
}
