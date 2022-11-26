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
                    Id = Guid.Parse("0bca0119-ffa5-4a45-b9ee-1d57d451c18e"),
                    AnimalId = Guid.Parse("27e35b5d-46da-4b0c-869b-d413045b468e"),
                    UserId = Guid.Parse("84712b0f-17cc-43a2-ae83-0536dad5e0c1"),
                    StartTime = DateTime.Parse("2022-1-12"),
                    FinishTime = DateTime.Parse("2022-1-12"), 
                    State = WalkState.Finished,
                    Comment = "Volunteer come late"
                },
                new Walk
                {
                    Id = Guid.Parse("21adc162-3acc-419f-91fe-2a1b00562f8b"),
                    AnimalId = Guid.Parse("5eb1cbe9-000f-4a1b-b4cb-d3dd9cf890d6"),
                    UserId = Guid.Parse("33be3fbb-9edf-4e2d-9ccc-c265b9af5b2c"),
                    StartTime = DateTime.Parse("2022-2-22"),
                    FinishTime = DateTime.Parse("2022-4-24"),
                    State = WalkState.NotStarted,
                    Comment = "Walk around city"
                },
                new Walk
                {
                    Id = Guid.Parse("ba934951-e7eb-481b-a843-033f2fcf4c3e"),
                    AnimalId = Guid.Parse("ad5c92e8-8a72-4eaf-b59a-0ca178c0fb45"),
                    UserId = Guid.Parse("78eb4516-8e37-4ed2-b386-2cf62ea8a61b"),
                    StartTime = DateTime.Parse("2022-1-12"),
                    FinishTime = DateTime.Parse("2022-2-12"),
                    State = WalkState.Started,
                    Comment = "Take animal home"
                }
            };
        }
    }
}