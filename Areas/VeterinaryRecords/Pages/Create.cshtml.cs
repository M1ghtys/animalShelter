using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using iis.Data;
using iis.Models;

namespace iis.Pages.VeterinaryRecords
{
    public class CreateModel : PageModel
    {
        private readonly iis.Data.DbContext _context;

        public CreateModel(iis.Data.DbContext context)
        {
            _context = context;
        }


        [BindProperty]
        public VeterinaryRecord VeterinaryRecord { get; set; }

        [BindProperty]
        public IList<Animal> Animals { get; set; }


        public IActionResult OnGet()
        {
            LoadData();
            return Page();
        }
        
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                LoadData();
                return Page();
            }

            _context.VeterinaryRecord.Add(VeterinaryRecord);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        void LoadData()
        {
            Animals = _context.Animal.ToList();
        }
    }
}
