using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using iis.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using iis.Models;

namespace iis.Data.Content
{
    public static class WalksList
    {
        public static List<Walk> GetWalks()
        {
            return new List<Walk>()
            {
                new iis.Models.Walk
                {
                    AnimalId = 1,
                    VolunteerId = 2,
                    StartTime = DateTime.Parse("20-12-2022 13:20"),
                    FinishTime = DateTime.Parse("20-12-2022 14:20"), 
                    State = WalkState.NotStarted,
                    Comment = ""
                },
                new iis.Models.Walk
                {
                    AnimalId = 2,
                    VolunteerId = 1,
                    StartTime = DateTime.Parse("21-12-2022 13:20"),
                    FinishTime = DateTime.Parse("21-12-2022 14:20"),
                    State = WalkState.NotStarted,
                    Comment = ""
                }
            };
        }
    }
}