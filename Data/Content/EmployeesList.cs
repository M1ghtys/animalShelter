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
                    PhoneNumber = "+420 945 512 645",
                    Email = "santaishere@email.com",
                    OccupationId = 1,
                    RecruitedDay = DateTime.Parse("2014-12-8"),
                },
                new Employee
                {
                    Name = "Jess Yellow",
                    Address = "Big Town 17",
                    PhoneNumber = "+41 516 25 85",
                    Email = "jessishere@email.com",
                    OccupationId = 2,
                    RecruitedDay = DateTime.Parse("2017-12-8"),
                },
                new Employee
                {
                    Name = "Jack Red",
                    Address = "Long Town 16",
                    PhoneNumber = "+18 85 4 552",
                    Email = "jackishere@email.com",
                    OccupationId = 3,
                    RecruitedDay = DateTime.Parse("2019-2-8"),
                },
                new Employee
                {
                    Name = "Charlie Brown",
                    Address = "Sweet Town 15",
                    PhoneNumber = "+18 75 9 552",
                    Email = "charlieishere@email.com",
                    OccupationId = 3,
                    RecruitedDay = DateTime.Parse("2019-3-8"),
                }
            };
        }
    }
}