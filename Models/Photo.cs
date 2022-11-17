using System;
using System.ComponentModel.DataAnnotations;

namespace iis.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public string Source { get; set; }
    }
}
