using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace iis.Models
{
    public enum Gender
    {
        Male,
        Female,
    }

    public enum Size
    {
        S,
        M,
        L,
    }

    public enum Territory
    {
        Outside,
        Inside,
        Both,
    }

    public enum Friendly
    {
        Kids,
        Animals,
        Both,
    }

    public class Animal
    {
        public int Id { get; set; }
        public string ChipNumber { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birth { get; set; }
        public DateTime DateOfArrival { get; set; }
        public Size Size { get; set; }
        public string About { get; set; }   
        public bool Reserved { get; set; }
        public Friendly Friendly { get; set; }
        public bool ForBeginners { get; set; }
        public Territory Territory { get; set; }
        
        public  HealthCondition? HealthCondition { get; set; }
        public ICollection<Walk> Walks { get; set; } = new Collection<Walk>();
        public ICollection<Photo> Photos { get; set; } = new Collection<Photo>();
        public ICollection<VeterinaryRecord> VeterinaryRecords { get; set; } = new Collection<VeterinaryRecord>();
    }
}
