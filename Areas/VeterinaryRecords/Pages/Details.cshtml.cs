using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using iis.Data;
using iis.Models;
using iis.Facades;

namespace iis.Pages.VeterinaryRecords
{
    public class DetailsModel : PageModel
    {
        private readonly iis.Data.DbContext _context;
        private readonly VeterinaryRecordFacade _facade;

        public DetailsModel(iis.Data.DbContext context)
        {
            _context = context;
            _facade = new VeterinaryRecordFacade(context);
        }

        public VeterinaryRecord VeterinaryRecord { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || !_facade.VeterinaryRecordExists(id))
            {
                return NotFound();
            }

            VeterinaryRecord = await _context.VeterinaryRecord.FirstOrDefaultAsync(m => m.Id == id);
            VeterinaryRecord.Animal = await _context.Animal.FirstOrDefaultAsync(m => m.Id == VeterinaryRecord.AnimalId);

            if (VeterinaryRecord == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
