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
        private readonly iis.Data.iisContext _context;

        public CreateModel(iis.Data.iisContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Walk Walk { get; set; }

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
