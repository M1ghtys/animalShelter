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
    [Authorize(Policy = "RequireCaretakerRole")]
    public class IndexModel : PageModel
    {
        private readonly iis.Data.DbContext _context;

        public IndexModel(iis.Data.DbContext context)
        {
            _context = context;
        }

        public string AnimalIDSort { get; set; }
        public string DateSort { get; set; }

        public IList<VeterinaryRecord> VeterinaryRecord { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            // using System;
            AnimalIDSort = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            DateSort = sortOrder == "Date" ? "Date_desc" : "Date";

            IQueryable<VeterinaryRecord> VetRecOrder = from s in _context.VeterinaryRecord
                                         select s;

            switch (sortOrder)
            {
                case "id_desc":
                    VetRecOrder = VetRecOrder.OrderByDescending(s => s.AnimalId);
                    break;
                case "Date":
                    VetRecOrder = VetRecOrder.OrderBy(s => s.Date);
                    break;
                case "Date_desc":
                    VetRecOrder = VetRecOrder.OrderByDescending(s => s.Date);
                    break;
                default:
                    VetRecOrder = VetRecOrder.OrderBy(s => s.AnimalId);
                    break;
            }

            VeterinaryRecord = await VetRecOrder.AsNoTracking().ToListAsync();
        }
    }
}
