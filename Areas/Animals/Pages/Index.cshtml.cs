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
            currentReservedChecked = false;
        }

        public IList<Animal> Animals { get; set; }

        public string BirthSort { get; set; }
        public string DateOASort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentFilterV { get; set; }
        public bool currentReservedChecked { get; set; }
        public bool currentReservedNotChecked { get; set; }

        public async Task<IActionResult> OnGetAsync(string search, int? order, int? reserved)
        {

            int orderBy = order.HasValue ? order.Value : 0;
            int reservedVal = reserved.HasValue ? reserved.Value : 0;

            string searchParams = search == null ? string.Empty : search.ToLower();

            return await LoadData(searchParams, orderBy, reservedVal);
        }

        public IActionResult OnPostCreate()
        {
            return RedirectToPage("Create");
        }

        public async Task<IActionResult> LoadData(string search, int order, int reserved)
        {
            IList<Animal> AnimalRecord = _context.Animal.ToList();
            

            foreach (var a in AnimalRecord)
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

            AnimalRecord = AnimalRecord
                .Where(a => a.Breed.ToLower().Contains(search))
                .ToList();

            switch (order)
            {
                case 1:
                    Animals = AnimalRecord.OrderBy(s => s.Birth).ToList();
                    break;
                case 2:
                    Animals = AnimalRecord.OrderBy(s => s.DateOfArrival).ToList();
                    break;
                case -1:
                    Animals = AnimalRecord.OrderByDescending(s => s.Birth).ToList();
                    break;
                case -2:
                    Animals = AnimalRecord.OrderByDescending(s => s.DateOfArrival).ToList();
                    break;
                default:
                    Animals = AnimalRecord.OrderBy(s => s.Id).ToList();
                    break;
            }

            if(reserved == 1)
            {
                Animals = Animals.Where(a => a.Reserved).ToList();
            }else if (reserved == -1)
            {
                Animals = Animals.Where(a => !a.Reserved).ToList();
            }

            return Page();
        }
    }
}
