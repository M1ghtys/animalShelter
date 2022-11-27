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
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace iis.Pages.Animals
{
    [Authorize(Roles = "Admin,Vet,Caretaker")]
    public class EditModel : PageModel
    {
        private readonly iis.Data.DbContext _context;
        private readonly AnimalFacade _facade;

        public EditModel(iis.Data.DbContext context)
        {
            _context = context;
            _facade = new AnimalFacade(context);
        }

        [BindProperty]
        public Animal Animal { get; set; }

        [BindProperty]
        public string Photo { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || !_facade.AnimalExists(id))
            {
                return NotFound();
            }

            Animal = await _context.Animal.FirstOrDefaultAsync(m => m.Id == id);
            Animal.Photos = _context.Photo.Where(p => p.AnimalId == Animal.Id).ToList();

            if (Animal == null)
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

            if (Photo != null)
            {
                _context.Photo.Add(new Photo()
                {
                    AnimalId = Animal.Id,
                    Source = Photo
                });
            }
            
            _context.Attach(Animal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_facade.AnimalExists(Animal.Id))
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
