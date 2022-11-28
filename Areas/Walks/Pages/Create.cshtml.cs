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

namespace iis.Pages.Walks
{
    [Authorize(Roles = "Admin,Caretaker")]
    public class CreateModel : PageModel
    {
        private readonly iis.Data.DbContext _context;

        [BindProperty]
        public Walk Walk { get; set; }
        
        [BindProperty]
        public IList<Animal> Animals { get; set; }
        [BindProperty]
        public IList<User> Users { get; set; }
        [BindProperty]
        public string SelectUser { get; set; }

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

            if(SelectUser != "None" && SelectUser != null)
            {

                var userId = _context.Users.Where(u => u.UserName == SelectUser).FirstOrDefault().Id;
                if(userId == null)
                {
                    throw new Exception("User not found");
                }

                Walk.UserId = Guid.Parse(userId);
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
