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
                new Walk
                {
                    AnimalId = 1,
                    VolunteerId = 3,
                    StartTime = DateTime.Parse("1-12-2022 13:20"),
                    FinishTime = DateTime.Parse("1-12-2022 14:20"), 
                    State = WalkState.Finished,
                    Comment = "Volunteer come late"
                },
                new Walk
                {
                    AnimalId = 2,
                    VolunteerId = 1,
                    StartTime = DateTime.Parse("21-12-2022 13:20"),
                    FinishTime = DateTime.Parse("21-12-2022 14:20"),
                    State = WalkState.NotStarted,
                    Comment = "Walk around city"
                },
                new Walk
                {
                    AnimalId = 3,
                    VolunteerId = 2,
                    StartTime = DateTime.Parse("15-12-2022 8:00"),
                    FinishTime = DateTime.Parse("15-12-2022 18:00"),
                    State = WalkState.Started,
                    Comment = "Take animal home"
                }
            };
        }
    }
}