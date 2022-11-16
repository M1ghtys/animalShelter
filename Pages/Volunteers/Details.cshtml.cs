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
    public class DetailsModel : PageModel
    {
        private readonly iis.Data.iisContext _context;
        private readonly VolunteerFacade _facade;

        public DetailsModel(iis.Data.iisContext context)
        {
            _context = context;
            _facade = new VolunteerFacade(context);
        }

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
    }
}
