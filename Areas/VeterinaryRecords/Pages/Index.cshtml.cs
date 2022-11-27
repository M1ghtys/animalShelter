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

namespace iis.Pages.VeterinaryRecords
{
    [Authorize(Roles = "Admin,Vet,Caretaker")]
    public class IndexModel : PageModel
    {
        private readonly iis.Data.DbContext _context;

        public IndexModel(iis.Data.DbContext context)
        {
            _context = context;
        }

        public string AnimalNameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }

        public IList<VeterinaryRecord> VeterinaryRecords { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            AnimalNameSort = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            DateSort = sortOrder == "Date" ? "Date_desc" : "Date";

            CurrentFilter = searchString;

            IList<VeterinaryRecord> VetRecOrder = _context.VeterinaryRecord.ToList();

            foreach (var v in VetRecOrder)
            {
                v.Animal = await _context.Animal.FirstOrDefaultAsync(a => a.Id == v.AnimalId);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                VetRecOrder = VetRecOrder.Where(s => s.Animal.Name.Contains(searchString)).ToList();
            }

            switch (sortOrder)
            {
                case "id_desc":
                    VeterinaryRecords = VetRecOrder.OrderByDescending(s => s.Animal.Name).ToList();
                    break;
                case "Date":
                    VeterinaryRecords = VetRecOrder.OrderBy(s => s.Date).ToList();
                    break;
                case "Date_desc":
                    VeterinaryRecords = VetRecOrder.OrderByDescending(s => s.Date).ToList();
                    break;
                default:
                    VeterinaryRecords = VetRecOrder.OrderBy(s => s.Animal.Name).ToList();
                    break;
            }

            foreach (var v in VeterinaryRecords)
            {
                v.Animal = await _context.Animal.FirstOrDefaultAsync(a => a.Id == v.AnimalId);
            }
        }
        public IActionResult OnPostCreate()
        {
            return RedirectToPage("Create");
        }
    }
}
