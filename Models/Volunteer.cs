using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace iis.Models
{
    public class Volunteer : Person
    {
        public bool Verified { get; set; }
        public string Comment { get; set; }
        
        public ICollection<Walk> Walks { get; set; } = new Collection<Walk>();
    }
}
