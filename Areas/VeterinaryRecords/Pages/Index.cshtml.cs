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

        public async Task<IActionResult> OnGetAsync(int? order, string search)
        {
            int orderBy = order.HasValue ? order.Value : 0;

            string searchParams = search == null ? string.Empty : search.ToLower();

            return await LoadData(orderBy, searchParams);
        }

        private async Task<IActionResult> LoadData(int order, string search)
        {
            var veterinaryRecords = _context.VeterinaryRecord.ToList();

            foreach (var v in veterinaryRecords)
            {
                v.Animal = await _context.Animal.FirstOrDefaultAsync(a => a.Id == v.AnimalId);
            }

            veterinaryRecords = veterinaryRecords.Where(v => v.Animal.Name.ToLower().Contains(search)).ToList();


            switch (order)
            {
                case 1:
                    VeterinaryRecords = veterinaryRecords.OrderBy(n => n.Animal.Name).ToArray();
                    break;
                case 2:
                    VeterinaryRecords = veterinaryRecords.OrderBy(n => n.Date).ToArray();
                    break;
                case -2:
                    VeterinaryRecords = veterinaryRecords.OrderByDescending(n => n.Date).ToArray();
                    break;
                case -1:
                    VeterinaryRecords = veterinaryRecords.OrderByDescending(n => n.Animal.Name).ToArray();
                    break;
                default:
                    VeterinaryRecords = veterinaryRecords.ToArray();
                    break;
            }

            return Page();
        }
        public IActionResult OnPostCreate()
        {
            return RedirectToPage("Create");
        }
    }
}
