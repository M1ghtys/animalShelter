using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using iis.Data;
using iis.Models;
using Microsoft.AspNetCore.Identity;

namespace iis.Pages.Users
{

    public class CreateModel : PageModel
    {
        private readonly iis.Data.DbContext _context;
        private readonly UserManager<Models.User> _userManager;

        

        public CreateModel(iis.Data.DbContext context, UserManager<iis.Models.User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public iis.Models.User User { get; set; }
        [BindProperty]
        public Role Role { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public bool UnverUser { get; set; }


        public IActionResult OnGet()
        {
            Role = Role.UnverifiedUser;
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            User.Id = Guid.NewGuid().ToString();

            if (User == null)
            {
                return Page();
            }

            if (Password == null)
            {
                Password = "useruser";
            }

            if (UnverUser)
            {
                Role = Role.UnverifiedUser;
            }
            
            var result = _userManager.CreateAsync(User, Password).Result;
            if (result.Succeeded)
            {
                result = _userManager.AddToRoleAsync(User, Roles.GetRoles()[Role]).Result;
            }

            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Insert role into db failed");
            }


            await _context.SaveChangesAsync();

            if (!UnverUser)
                return RedirectToPage("./Index");
            else
                return Redirect("~/Account/Login");
        }
    }
}
