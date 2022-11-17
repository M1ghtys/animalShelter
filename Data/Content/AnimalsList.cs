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
                new Animal
                {
                    ChipNumber = "CZ000001",
                    Name = "George",
                    Breed = "Monke",
                    Gender = Gender.Male,
                    Birth = DateTime.Parse("1984-1-1"),
                    DateOfArrival = DateTime.Parse("1984-1-2"),
                    Size = Size.L,
                    About = "Big Monke",
                    Reserved = true,
                    Friendly = Friendly.Animals,
                    ForBeginners = false,
                    Territory = Territory.Inside
                },
                new Animal
                {
                    ChipNumber = "CZ000002",
                    Name = "Pepah",
                    Breed = "Horse",
                    Gender = Gender.Male,
                    Birth = DateTime.Parse("1966-1-1"),
                    DateOfArrival = DateTime.Parse("1967-1-2"),
                    Size = Size.S,
                    About = "Horse",
                    Reserved = false,
                    Friendly = Friendly.Both,
                    ForBeginners = true,
                    Territory = Territory.Outside
                },
                new Animal
                {
                    ChipNumber = "CZ000003",
                    Name = "Arthur",
                    Breed = "Dog",
                    Gender = Gender.Male,
                    Birth = DateTime.Parse("2016-1-1"),
                    DateOfArrival = DateTime.Parse("2020-1-2"),
                    Size = Size.S,
                    About = "Big Dog",
                    Reserved = false,
                    Friendly = Friendly.Both,
                    ForBeginners = false,
                    Territory = Territory.Inside
                }
            };
        }
    }
}