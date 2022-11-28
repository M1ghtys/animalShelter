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
using System.ComponentModel.DataAnnotations;

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
        [BindProperty]
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [BindProperty]
        [Required]
        [RegularExpression(@"(?:[+]{1}[0-9]{2,3})?[0-9]{3}[0-9]{3}[0-9]{3}", ErrorMessage = "Invalid Phone Number")]

        public string PhoneNumber { get; set; }
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

            Email = UserModel.Email;
            PhoneNumber = UserModel.PhoneNumber;

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
            user.PhoneNumber = PhoneNumber;
            user.Email = Email;
            

            var savingResult = await _context.SaveChangesAsync();

            if(savingResult == 0)
            {
                ModelState.AddModelError("", "No Change Was Made");
                return Page();
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
