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
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace iis.Pages.Animals
{
    public class DetailsModel : PageModel
    {
        private readonly iis.Data.DbContext _context;
        private readonly AnimalFacade _facade;

        public DetailsModel(iis.Data.DbContext context)
        {
            _context = context;
            _facade = new AnimalFacade(context);
        }

        public Animal Animal { get; set; }
        
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || !_facade.AnimalExists(id))
            {
                return NotFound();
            }

            Animal = await _context.Animal.FirstOrDefaultAsync(m => m.Id == id);
            Animal.Photos = _context.Photo.Where(m => m.AnimalId == Animal.Id).ToList();
            Animal.VeterinaryRecords = _context.VeterinaryRecord.Where(m => m.AnimalId == Animal.Id).ToList();

            if (Animal == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
