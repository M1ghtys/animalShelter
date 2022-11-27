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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace iis.Pages.Users
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly iis.Data.DbContext _context;
        private readonly UserManager<Models.User> _userManager;
        private readonly UserFacade _facade;

        public EditModel(iis.Data.DbContext context, UserManager<iis.Models.User> userManager)
        {
            _context = context;
            _userManager = userManager;
            _facade = new UserFacade(context, userManager);
        }

        [BindProperty]
        public User UserModel { get; set; }
        [BindProperty]
        public Role Role { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || !_facade.UserExists(id))
            {
                return NotFound();
            }

            UserModel = await _context.Users.FirstOrDefaultAsync(m => m.Id == id.ToString());
            //UserModel.Role = await _facade.GetUserRoleAsync(id.ToString());
           
            if (UserModel == null)
            {
                return NotFound();
            }

            Role = await _facade.GetUserRoleAsync(UserModel.Id);

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

            var duplicate = await _facade.UsernameExists(UserModel);
            if (duplicate)
            {
                return Page();
            }
           
            var user = await _context.Users.FirstAsync(user => user.Id == UserModel.Id);
            user.Name = UserModel.Name;
            user.UserName = UserModel.UserName;
            user.Address = UserModel.Address;
            user.PhoneNumber = UserModel.PhoneNumber;
            user.Email = UserModel.Email;
            

            var savingResult = await _context.SaveChangesAsync();

            if (savingResult == 0)
            {
                ModelState.AddModelError("", "No Change Was Made");
                return Page();
            }

            
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.FirstOrDefault() != Role.ToString())
            {
                var result = await _userManager.RemoveFromRolesAsync(user, roles);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot remove user roles");
                    return Page();
                }
                result = await _userManager.AddToRoleAsync(user, Role.ToString());
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot add roles to user");
                    return Page();
                }
            }

            return RedirectToPage("Index", new { area = "Users" });
        }

        public async Task<IActionResult> OnPostChangePasswordAsync()
        {
            if (String.IsNullOrEmpty(Password))
            {
                ModelState.AddModelError("", "Password Cannot Be Empty");
                return Page();
            }
            var user = await _context.Users.FirstAsync(user => user.Id == UserModel.Id);
            var passwordHasher = _userManager.PasswordHasher;
            var pw = passwordHasher.HashPassword(user, Password);
            user.PasswordHash = pw;


            var tt = await _context.SaveChangesAsync();
            return RedirectToPage("Index", new { area = "Users" });
        }
    }
}
