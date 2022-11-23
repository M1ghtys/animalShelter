using System;

namespace iis.Models
{
    public class Employee : User
    {
        public int OccupationId { get; set; }
        public Occupation? Occupation { get; set; }
        public DateTime RecruitedDay { get; set; }
    }
}
