using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iis.Data;
using iis.Facades;
using iis.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace iis.Pages.VeterinaryRecords
{
    [Authorize(Roles = "Admin,Vet,Caretaker")]
    public class EditModel : PageModel
    {
        private readonly iis.Data.DbContext _context;
        private readonly VeterinaryRecordFacade _facade;

        public EditModel(iis.Data.DbContext context)
        {
            _context = context;
            _facade = new VeterinaryRecordFacade(context);
        }

        [BindProperty]
        public VeterinaryRecord VeterinaryRecord { get; set; }

        [BindProperty]
        public IList<Animal> Animals { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            LoadData();
            if (id == null || !_facade.VeterinaryRecordExists(id))
            {
                return NotFound();
            }

            VeterinaryRecord = await _context.VeterinaryRecord.FirstOrDefaultAsync(m => m.Id == id);

            if (VeterinaryRecord == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(VeterinaryRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_facade.VeterinaryRecordExists(VeterinaryRecord.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        void LoadData()
        {
            Animals = _context.Animal.ToList();
        }
    }
}
