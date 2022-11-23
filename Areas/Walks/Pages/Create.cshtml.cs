using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using iis.Data;
using iis.Models;

namespace iis.Pages.Walks
{

    public class CreateModel : PageModel
    {
        private readonly iis.Data.DbContext _context;

        [BindProperty]
        public Walk Walk { get; set; }
        [BindProperty]
        public Volunteer Volunteer { get; set; }

        public CreateModel(iis.Data.DbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Walk.Add(Walk);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
