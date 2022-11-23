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
    public class PhotoDeleteModel : PageModel
    {
        private readonly iis.Data.iisContext _context;

        public PhotoDeleteModel(iis.Data.iisContext context)
        {
            _context = context;
        }

        public Photo Photo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Photo = await _context.Photo.FirstOrDefaultAsync(m => m.Id == id);

            if (Photo != null)
            {
                _context.Photo.Remove(Photo);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToPage("./Index");
        }
    }
}
