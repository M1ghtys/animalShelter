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
                    StartTime = DateTime.Parse("2022-1-12"),
                    FinishTime = DateTime.Parse("2022-1-12"), 
                    State = WalkState.Finished,
                    Comment = "Volunteer come late"
                },
                new Walk
                {
                    AnimalId = 2,
                    VolunteerId = 1,
                    StartTime = DateTime.Parse("2022-2-22"),
                    FinishTime = DateTime.Parse("2022-4-24"),
                    State = WalkState.NotStarted,
                    Comment = "Walk around city"
                },
                new Walk
                {
                    AnimalId = 3,
                    VolunteerId = 2,
                    StartTime = DateTime.Parse("2022-1-12"),
                    FinishTime = DateTime.Parse("2022-2-12"),
                    State = WalkState.Started,
                    Comment = "Take animal home"
                }
            };
        }
    }
}