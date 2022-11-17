using System;
using System.ComponentModel.DataAnnotations;

namespace iis.Models
{
    public class Employee : Person
    {
        public int OccupationId { get; set; }
        public DateTime RecruitedDay { get; set; }
    }
}
