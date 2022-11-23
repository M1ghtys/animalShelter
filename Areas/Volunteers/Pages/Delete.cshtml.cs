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

namespace iis.Pages.Volunteers
{
    public class DeleteModel : PageModel
    {
        private readonly iis.Data.DbContext _context;
        private readonly VolunteerFacade _facade;

        public DeleteModel(iis.Data.DbContext context)
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

            Volunteer = await _context.Volunteer.FirstOrDefaultAsync(m => m.Id == id.ToString());

            if (Volunteer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || !_facade.VolunteerExists(id))
            {
                return NotFound();
            }

            Volunteer = await _context.Volunteer.FindAsync(id);

            if (Volunteer != null)
            {
                _context.Volunteer.Remove(Volunteer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
