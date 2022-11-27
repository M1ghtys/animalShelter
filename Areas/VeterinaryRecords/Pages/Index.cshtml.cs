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

        public IList<VeterinaryRecord> VeterinaryRecords { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            AnimalNameSort = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            DateSort = sortOrder == "Date" ? "Date_desc" : "Date";

            IQueryable<VeterinaryRecord> VetRecOrder = from s in _context.VeterinaryRecord
                                         select s;

            foreach (var v in VetRecOrder)
            {
                v.Animal = await _context.Animal.FirstOrDefaultAsync(a => a.Id == v.AnimalId);
            }

            switch (sortOrder)
            {
                case "id_desc":
                    VetRecOrder = VetRecOrder.OrderByDescending(s => s.Animal.Name);
                    break;
                case "Date":
                    VetRecOrder = VetRecOrder.OrderBy(s => s.Date);
                    break;
                case "Date_desc":
                    VetRecOrder = VetRecOrder.OrderByDescending(s => s.Date);
                    break;
                default:
                    VetRecOrder = VetRecOrder.OrderBy(s => s.Animal.Name);
                    break;
            }

            VeterinaryRecords = await VetRecOrder.AsNoTracking().ToListAsync();

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
