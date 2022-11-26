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
        public Guid Id { get; set; }
        public Guid AnimalId { get; set; }
        public Animal? Animal { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public WalkState State { get; set; }
        public string Comment { get; set; }
    }
}
