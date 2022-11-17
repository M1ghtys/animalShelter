using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using iis.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using iis.Models;

namespace iis.Data.Content
{
    public static class EmployeesList
    {
        public static List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee
                {
                    Name = "Santa Claus",
                    Address = "North Pole 4",
                    Phone = "+420 945 512 645",
                    Email = "santaishere@email.com",
                    OccupationId = 1,
                    RecruitedDay = DateTime.Parse("12-8-2014"),
                },
                new Employee
                {
                    Name = "Jess Yellow",
                    Address = "Big Town 17",
                    Phone = "+41 516 25 85",
                    Email = "jessishere@email.com",
                    OccupationId = 2,
                    RecruitedDay = DateTime.Parse("12-8-2017"),
                },
                new Employee
                {
                    Name = "Jack Red",
                    Address = "Long Town 16",
                    Phone = "+18 85 4 552",
                    Email = "jackishere@email.com",
                    OccupationId = 3,
                    RecruitedDay = DateTime.Parse("12-8-2019"),
                }
            };
        }
    }
}