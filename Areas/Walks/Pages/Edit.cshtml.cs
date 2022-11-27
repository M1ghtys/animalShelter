using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iis.Data;
using iis.Facades;
using iis.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace iis.Pages.Walks
{
    [Authorize(Roles = "Admin,Caretaker")]
    public class EditModel : PageModel
    {
        private readonly iis.Data.DbContext _context;
        private readonly WalkFacade _facade;

        public EditModel(iis.Data.DbContext context)
        {
            _context = context;
            _facade = new WalkFacade(context);
        }

        [BindProperty]
        public Walk Walk { get; set; }

        [BindProperty]
        public IList<Animal> Animals { get; set; }
        [BindProperty]
        public IList<User> Users { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            LoadData();
            if (id == null || !_facade.WalkExists(id))
            {
                return NotFound();
            }

            Walk = await _context.Walk.FirstOrDefaultAsync(m => m.Id == id);

            if (Walk == null)
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

            _context.Attach(Walk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_facade.WalkExists(Walk.Id))
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

        void LoadData()
        {
            Animals = _context.Animal.ToList();
            Users = _context.Users.ToList();
        }
    }
}
