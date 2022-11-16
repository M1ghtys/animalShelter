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

namespace iis.Pages.Walks
{
    public class DeleteModel : PageModel
    {
        private readonly iis.Data.iisContext _context;
        private readonly WalkFacade _facade;

        public DeleteModel(iis.Data.iisContext context)
        {
            _context = context;
            _facade = new WalkFacade(context);
        }

        [BindProperty]
        public Walk Walk { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || !_facade.WalkExists(id))
            {
                return NotFound();
            }

            Walk = await _context.Walk.FirstOrDefaultAsync(m => m.Id == id);

            if (Walk == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || !_facade.WalkExists(id))
            {
                return NotFound();
            }

            Walk = await _context.Walk.FindAsync(id);

            if (Walk != null)
            {
                _context.Walk.Remove(Walk);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
