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
                    Date = DateTime.Parse("1984-1-2"),
                    Weight = 16.70,
                    Details = "Weight check at arrival."
                },
                new VeterinaryRecord
                {
                    AnimalId = 2,
                    Date = DateTime.Parse("2022-6-12"),
                    Weight = 5.45,
                    Details = "Inflammation discovered in the left ear."
                },
                new VeterinaryRecord
                {
                    AnimalId = 2,
                    Date = DateTime.Parse("2022-5-12"),
                    Weight = 5.45,
                    Details = "Injection given for inflammation in the ear."
                },
                new VeterinaryRecord
                {
                    AnimalId = 3,
                    Date = DateTime.Parse("2021-2-6"),
                    Weight = 7.15,
                    Details = "Amputation of right hind leg due to infection."
                }
            };
        }
    }
}