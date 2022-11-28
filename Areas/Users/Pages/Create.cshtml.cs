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
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using iis.Facades;
using System.ComponentModel.DataAnnotations;

namespace iis.Pages.Users
{

    public class CreateModel : PageModel
    {
        private readonly iis.Data.DbContext _context;
        private readonly UserManager<Models.User> _userManager;
        private readonly UserFacade _facade;

        public CreateModel(iis.Data.DbContext context, UserManager<iis.Models.User> userManager)
        {
            _context = context;
            _userManager = userManager;
            _facade = new UserFacade(context, userManager);
        }

        [BindProperty]
        public iis.Models.User User { get; set; }
        [BindProperty]
        public Role Role { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage ="Invalid Email")]
        public string Email { get; set; }
        [BindProperty]
        [Required]
        [RegularExpression(@"(?:[+]{1}[0-9]{2,3})?[0-9]{3}[0-9]{3}[0-9]{3}", ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }
        [BindProperty]
        public bool UnverUser { get; set; }
        [BindProperty]
        public bool DuplicateUserName { get; set; }


        public IActionResult OnGet()
        {
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

            DuplicateUserName = await _facade.UsernameExists(User);
            if (DuplicateUserName)
            {
                return Page();
            }


            if (Password == null)
            {
                ModelState.AddModelError("","Password Cannot Be Empty");
                return Page();
            }

            if (UnverUser)
            {
                Role = Role.UnverifiedUser;
            }
            //add regex values
            User.Email = Email;
            User.PhoneNumber = PhoneNumber;
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
