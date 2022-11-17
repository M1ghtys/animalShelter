using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using iis.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using iis.Models;

namespace iis.Data.Content
{
    public static class HealthConditionsList
    {
        public static List<HealthCondition> GetHealthConditions()
        {
            return new List<HealthCondition>()
            {
                new HealthCondition
                {
                    AnimalId = 1,
                    Tattoo = false,
                    Castration = true,
                    Vaccinated = true,
                    Handicapped = false,
                    Others = "Well condition"
                },
                new HealthCondition
                {
                    AnimalId = 2,
                    Tattoo = false,
                    Castration = true,
                    Vaccinated = true,
                    Handicapped = false,
                    Others = "He's got an ear infection"
                },
                new HealthCondition
                {
                    AnimalId = 3,
                    Tattoo = true,
                    Castration = false,
                    Vaccinated = false,
                    Handicapped = true,
                    Others = "His right hind leg has been amputated."
                }
            };
        }
    }
}