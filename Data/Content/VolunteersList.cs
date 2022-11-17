using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using iis.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using iis.Models;

namespace iis.Data.Content
{
    public static class VolunteersList
    {
        public static List<Volunteer> GetVolunteers()
        {
            return new List<Volunteer>()
            {
                new Volunteer
                {
                    Name = "Eric Green",
                    Address = "Old Town 35",
                    Phone = "+420 854 815 645",
                    Email = "ericishere@email.com",
                    Verified = true,
                    Comment = "Nice guy"
                },
                new Volunteer
                {
                    Name = "Jenny Blue",
                    Address = "New Town 36",
                    Phone = "+15 654 215",
                    Email = "jennyishere@email.com",
                    Verified = false,
                    Comment = "Dogs loves her"
                },
                new Volunteer
                {
                    Name = "John Black",
                    Address = "Small Town 37",
                    Phone = "+178 154 754 215",
                    Email = "johnishere@email.com",
                    Verified = true,
                    Comment = "Always late"
                }
            };
        }
    }
}