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
        public List<string> Roles { get; set; } = new List<string>();

        public async Task<IActionResult> OnGetAsync(int? order, string search)
        {
            int orderBy = order.HasValue ? order.Value : 0;

            string searchParams = search == null ? string.Empty : search.ToLower();

            return await LoadData(orderBy, searchParams);
        }

        private async Task<IActionResult> LoadData(int order, string search)
        {
            var users = _context.Users.ToList();

            users = users
                .Where(u => u.UserName.ToLower().Contains(search))
                .ToList();

            switch (order)
            {
                case 1:
                    Users = users.OrderBy(n => n.UserName).ToArray();
                    break;
                case 2:
                    Users = users.OrderBy(n => n.Email).ToArray();
                    break;
                case -1:
                    Users = users.OrderByDescending(n => n.UserName).ToArray();
                    break;
                case -2:
                    Users = users.OrderByDescending(n => n.Email).ToArray();
                    break;
                default:
                    Users = users.ToArray();
                    break;
            }

            //get roles after filter => correct order
            foreach (var u in Users)
            {
                var role = await _facade.GetUserRoleAsync(u.Id);
                Roles.Add(role.ToString());
            }

            return Page();
        }

        public IActionResult OnPostCreate()
        {
            return RedirectToPage("Create");
        }
    }
}
