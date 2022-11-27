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
        public string CurrentFilter { get; set; }
        public string CurrentFilterV { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString, string searchStringV)
        {

            BirthSort = String.IsNullOrEmpty(sortOrder) ? "birth_desc" : "";
            DateOASort = sortOrder == "DateOA" ? "DateOA_desc" : "DateOA";

            CurrentFilter = searchString;
            CurrentFilterV = searchStringV;

            IList<Animal> AnimalRecord = _context.Animal.ToList();
            Animals = AnimalRecord;

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

            if (!String.IsNullOrEmpty(searchString))
            {
                AnimalRecord = AnimalRecord.Where(s => s.Breed.Contains(searchString)).ToList();
            }

            if (!String.IsNullOrEmpty(searchStringV))
            {
                if(searchStringV == "reserved")
                {
                    AnimalRecord = AnimalRecord.Where(s => s.Reserved).ToList();
                } else if(searchStringV == "not reserved")
                {
                    AnimalRecord = AnimalRecord.Where(s => !s.Reserved).ToList();
                }
                
            }

            switch (sortOrder)
            {
                case "birth_desc":
                    Animals = AnimalRecord.OrderByDescending(s => s.Birth).ToList();
                    break;
                case "DateOA":
                    Animals = AnimalRecord.OrderBy(s => s.DateOfArrival).ToList();
                    break;
                case "DateOA_desc":
                    Animals = AnimalRecord.OrderByDescending(s => s.DateOfArrival).ToList();
                    break;
                default:
                    Animals = AnimalRecord.OrderBy(s => s.Id).ToList();
                    break;
            }

        }

        public IActionResult OnPostCreate()
        {
            return RedirectToPage("Create");
        }
    }
}
