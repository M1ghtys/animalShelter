using System;
using System.ComponentModel.DataAnnotations;

namespace iis.Models
{
    public class Employee : User
    {
        public int OccupationId { get; set; }
        public DateTime RecruitedDay { get; set; }
    }
}
