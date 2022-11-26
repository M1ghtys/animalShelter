using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using iis.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using iis.Models;

namespace iis.Data.Content
{
    public static class VeterinaryRecordsList
    {
        public static List<VeterinaryRecord> GetVeterinaryRecords()
        {
            return new List<VeterinaryRecord>()
            {
                new VeterinaryRecord
                {
                    Id = Guid.Parse("ed7eccf1-66bb-47e9-886d-860f2356e3ba"),
                    AnimalId = Guid.Parse("27e35b5d-46da-4b0c-869b-d413045b468e"),
                    Date = DateTime.Parse("1984-1-2"),
                    Weight = 16.70,
                    Details = "Weight check at arrival."
                },
                new VeterinaryRecord
                {
                    Id = Guid.Parse("2b321280-ee04-4348-bc21-66abcc9b2c07"),
                    AnimalId = Guid.Parse("5eb1cbe9-000f-4a1b-b4cb-d3dd9cf890d6"),
                    Date = DateTime.Parse("2022-6-12"),
                    Weight = 5.45,
                    Details = "Inflammation discovered in the left ear."
                },
                new VeterinaryRecord
                {
                    Id = Guid.Parse("d852e633-ef0d-48b1-84b6-a4ce6743fe0b"),
                    AnimalId = Guid.Parse("5eb1cbe9-000f-4a1b-b4cb-d3dd9cf890d6"),
                    Date = DateTime.Parse("2022-5-12"),
                    Weight = 5.45,
                    Details = "Injection given for inflammation in the ear."
                },
                new VeterinaryRecord
                {
                    Id = Guid.Parse("a76c2435-e914-4ae1-b958-e9903f4eb6d9"),
                    AnimalId = Guid.Parse("27e35b5d-46da-4b0c-869b-d413045b468e"),
                    Date = DateTime.Parse("2021-2-6"),
                    Weight = 7.15,
                    Details = "Amputation of right hind leg due to infection."
                }
            };
        }
    }
}