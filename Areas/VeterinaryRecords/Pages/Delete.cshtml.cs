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
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace iis.Pages.VeterinaryRecords
{
    [Authorize(Roles = "Admin,Vet,Caretaker")]
    public class DeleteModel : PageModel
    {
        private readonly iis.Data.DbContext _context;
        private readonly VeterinaryRecordFacade _facade;

        public DeleteModel(iis.Data.DbContext context)
        {
            _context = context;
            _facade = new VeterinaryRecordFacade(context);
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || !_facade.VeterinaryRecordExists(id))
            {
                return NotFound();
            }

            VeterinaryRecord = await _context.VeterinaryRecord.FindAsync(id);

            if (VeterinaryRecord != null)
            {
                _context.VeterinaryRecord.Remove(VeterinaryRecord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
