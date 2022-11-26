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
        public IList<Animal> Animals { get; set; }
        [BindProperty]
        public IList<User> Users { get; set; }

        public CreateModel(iis.Data.DbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            LoadData();
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Walk.Id = Guid.NewGuid();

            if (Walk == null)
            {
                LoadData();
                return Page();
            }

            _context.Walk.Add(Walk);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        void LoadData()
        {
            Animals = _context.Animal.ToList();
            Users = _context.Users.ToList();
        }
    }
}
