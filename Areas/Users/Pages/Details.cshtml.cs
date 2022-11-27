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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace iis.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly iis.Data.DbContext _context;
        private readonly UserFacade _facade;

        public DetailsModel(iis.Data.DbContext context, UserManager<iis.Models.User> userManager)
        {
            _context = context;
            _facade = new UserFacade(context, userManager);
        }

        public User User { get; set; }
        public Role Role { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || !_facade.UserExists(id))
            {
                return NotFound();
            }
            
            User = await _context.Users.FirstOrDefaultAsync(m => m.Id == id.ToString());
            Role = await _facade.GetUserRoleAsync(id.ToString());
            
            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
