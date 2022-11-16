using System;
using System.ComponentModel.DataAnnotations;

namespace iis.Models
{
    public enum WalkState
    {
        NotStarted,
        Started,
        Finished,
    }

    public class Walk
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public int VolunteerId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public WalkState State { get; set; }
        public string Comment { get; set; }
    }
}
