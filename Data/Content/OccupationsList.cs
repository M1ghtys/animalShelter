using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using iis.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using iis.Models;

namespace iis.Data.Content
{
    public static class OccupationsList
    {
        public static List<Occupation> GetOccupations()
        {
            return new List<Occupation>()
            {
                new Occupation
                {
                    Name = "Admin",
                    Permissions = 1,
                    Pay = 16200.00
                },
                new Occupation
                {
                    Name = "Shelter nurse",
                    Permissions = 2,
                    Pay = 35000.00
                },
                new Occupation
                {
                    Name = "Vet",
                    Permissions = 3,
                    Pay = 22320.50
                }
            };
        }
    }
}