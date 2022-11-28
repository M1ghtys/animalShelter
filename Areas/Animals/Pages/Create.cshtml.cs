using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using iis.Data;
using iis.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace iis.Pages.Animals
{
    [Authorize(Roles = "Admin,Caretaker")]
    public class CreateModel : PageModel
    {
        private readonly iis.Data.DbContext _context;

        public CreateModel(iis.Data.DbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Animal Animal { get; set; }

        [BindProperty]
        public string Photo { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(_context.Animal.Where(x => x.ChipNumber == Animal.ChipNumber).FirstOrDefault() != null)
            {
                ModelState.AddModelError("", "Chip Number Already Exists");
                return Page();
            }

            _context.Animal.Add(Animal);

            await _context.SaveChangesAsync();

            if (Photo != null)
            {
                _context.Photo.Add(new Photo()
                {
                    AnimalId = Animal.Id,
                    Source = Photo
                });
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
