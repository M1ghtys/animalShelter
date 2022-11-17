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
                    AnimalId = 1,
                    Date = DateTime.Parse("1-2-1984 14:00"),
                    Weight = 16.70,
                    Details = "Weight check at arrival."
                },
                new VeterinaryRecord
                {
                    AnimalId = 2,
                    Date = DateTime.Parse("13-12-2022 11:00"),
                    Weight = 5.45,
                    Details = "Inflammation discovered in the left ear."
                },
                new VeterinaryRecord
                {
                    AnimalId = 2,
                    Date = DateTime.Parse("14-12-2022 11:00"),
                    Weight = 5.45,
                    Details = "Injection given for inflammation in the ear."
                },
                new VeterinaryRecord
                {
                    AnimalId = 3,
                    Date = DateTime.Parse("30-6-2021 12:00"),
                    Weight = 7.15,
                    Details = "Amputation of right hind leg due to infection."
                }
            };
        }
    }
}