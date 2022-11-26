using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using iis.Data;
using iis.Models;
using Microsoft.AspNetCore.Authorization;

namespace iis.Pages.Animals
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly iis.Data.DbContext _context;

        public IndexModel(iis.Data.DbContext context)
        {
            _context = context;
        }

        public IList<Animal> Animals { get;set; }

        public string BirthSort { get; set; }
        public string DateOASort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {

            BirthSort = String.IsNullOrEmpty(sortOrder) ? "birth_desc" : "";
            DateOASort = sortOrder == "DateOA" ? "DateOA_desc" : "DateOA";

            IQueryable<Animal> AnimalRecord = from s in _context.Animal
                                                       select s;

            switch (sortOrder)
            {
                case "birth_desc":
                    AnimalRecord = AnimalRecord.OrderByDescending(s => s.Birth);
                    break;
                case "DateOA":
                    AnimalRecord = AnimalRecord.OrderBy(s => s.DateOfArrival);
                    break;
                case "DateOA_desc":
                    AnimalRecord = AnimalRecord.OrderByDescending(s => s.DateOfArrival);
                    break;
                default:
                    AnimalRecord = AnimalRecord.OrderBy(s => s.Id);
                    break;
            }

            Animals = await AnimalRecord.AsNoTracking().ToListAsync();
            foreach (var a in Animals)
            {
                a.Photos = _context.Photo.Where(p => p.AnimalId == a.Id).ToList();
                if (!a.Photos.Any())
                {
                    a.Photos.Add(new Photo()
                    {
                        AnimalId = a.Id,
                        Source = "https://storage.googleapis.com/proudcity/mebanenc/uploads/2021/03/placeholder-image.png"
                    });
                }
            }
        }

        public IActionResult OnPostCreate()
        {
            return RedirectToPage("Create");
        }
    }
}
