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
                    Id = Guid.Parse("27e35b5d-46da-4b0c-869b-d413045b468e"),
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
                    Territory = Territory.Inside,
                    Tattoo = false,
                    Castration = true,
                    Vaccinated = true,
                    Handicapped = false,
                    Comment = "Well condition"
                },
                new Animal
                {
                    Id = Guid.Parse("5eb1cbe9-000f-4a1b-b4cb-d3dd9cf890d6"),
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
                    Territory = Territory.Outside,
                    Tattoo = false,
                    Castration = true,
                    Vaccinated = true,
                    Handicapped = false,
                    Comment = "He's got an ear infection"
                },
                new Animal
                {
                    Id = Guid.Parse("ad5c92e8-8a72-4eaf-b59a-0ca178c0fb45"),
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
                    Territory = Territory.Inside,
                    Tattoo = true,
                    Castration = false,
                    Vaccinated = false,
                    Handicapped = true,
                    Comment = "His right hind leg has been amputated."
                }
            };
        }
    }
}