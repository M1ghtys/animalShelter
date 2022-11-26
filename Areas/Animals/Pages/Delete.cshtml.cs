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

namespace iis.Pages.Animals
{
    public class DeleteModel : PageModel
    {
        private readonly iis.Data.DbContext _context;
        private readonly AnimalFacade _facade;

        public DeleteModel(iis.Data.DbContext context)
        {
            _context = context;
            _facade = new AnimalFacade(context);
        }

        [BindProperty]
        public Animal Animal { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || !_facade.AnimalExists(id))
            {
                return NotFound();
            }

            Animal = await _context.Animal.FirstOrDefaultAsync(m => m.Id == id);

            if (Animal == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || !_facade.AnimalExists(id))
            {
                return NotFound();
            }

            Animal = await _context.Animal.FindAsync(id);

            if (Animal != null)
            {
                _context.Animal.Remove(Animal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
