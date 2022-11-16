using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iis.Data;
using iis.Models;
using iis.Facades;

namespace iis.Pages.Volunteers
{
    public class EditModel : PageModel
    {
        private readonly iis.Data.iisContext _context;
        private readonly VolunteerFacade _facade;

        public EditModel(iis.Data.iisContext context)
        {
            _context = context;
            _facade = new VolunteerFacade(context);
        }

        [BindProperty]
        public Volunteer Volunteer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || !_facade.VolunteerExists(id))
            {
                return NotFound();
            }

            Volunteer = await _context.Volunteer.FirstOrDefaultAsync(m => m.Id == id);

            if (Volunteer == null)
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

            _context.Attach(Volunteer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_facade.VolunteerExists(Volunteer.Id))
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
    }
}
