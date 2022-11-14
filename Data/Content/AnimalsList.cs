using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using iis.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using iis.Models;

namespace iis.Data.Content
{
    public static class AnimalsList
    {
        public static List<Animal> GetAnimals()
        {
            return new List<Animal>()
            {
                new iis.Models.Animal
                {
                    ChipNumber = "CZ000001",
                    Name = "George",
                    Breed = "Monke",
                    Gender = iis.Models.Gender.Male,
                    Birth = DateTime.Parse("1984-1-1"),
                    DateOfArrival = DateTime.Parse("1984-1-2"),
                    Size = iis.Models.Size.L,
                    About = "Big Monke",
                    Reserved = true,
                    Friendly = iis.Models.Friendly.Animals,
                    ForBeginners = false,
                    Territory = iis.Models.Territory.Inside,
                },
                new iis.Models.Animal
                {
                    ChipNumber = "CZ000002",
                    Name = "Pepah",
                    Breed = "Not Monke",
                    Gender = iis.Models.Gender.Male,
                    Birth = DateTime.Parse("1966-1-1"),
                    DateOfArrival = DateTime.Parse("1967-1-2"),
                    Size = iis.Models.Size.S,
                    About = "Non-Monke",
                    Reserved = false,
                    Friendly = iis.Models.Friendly.Both,
                    ForBeginners = true,
                    Territory = iis.Models.Territory.Outside,
                }
            };
        }
    }
}