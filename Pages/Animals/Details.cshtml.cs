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
    public class DetailsModel : PageModel
    {
        private readonly iis.Data.iisContext _context;
        private readonly AnimalFacade _facade;

        public DetailsModel(iis.Data.iisContext context)
        {
            _context = context;
            _facade = new AnimalFacade(context);
        }

        public Animal Animal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || !_facade.AnimalExists(id))
            {
                return NotFound();
            }

            Animal = await _context.Animal.FirstOrDefaultAsync(m => m.Id == id);
            Animal.Photos = _context.Photo.Where(m => m.AnimalId == Animal.Id).ToList();
            Animal.HealthCondition = _context.HealthCondition.FirstOrDefault(m => m.AnimalId == Animal.Id);

            if (Animal == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
