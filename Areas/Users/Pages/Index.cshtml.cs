using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using iis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using iis.Data;
using iis.Facades;
using Microsoft.AspNetCore.Identity;

namespace iis.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly iis.Data.DbContext _context;
        private readonly UserManager<Models.User> _userManager;
        private readonly UserFacade _facade;

        public IndexModel(iis.Data.DbContext context, UserManager<iis.Models.User> userManager)
        {
            _context = context;
            _userManager = userManager;
            _facade = new UserFacade(context, userManager);
        }
        
        public IList<User> Users { get;set; }

        public async Task OnGetAsync()
        {
            Users = _context.Users.ToList();
            foreach (var u in Users)
            {
                u.Role = await _facade.GetUserRoleAsync(u.Id);
            }
        }

        public IActionResult OnPostCreate()
        {
            return RedirectToPage("Create");
        }
    }
}
