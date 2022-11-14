using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using iis.Data;
using iis.Models;

namespace iis.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly iis.Data.iisContext _context;

        public LoginModel(iis.Data.iisContext context)
        {
            _context = context;
        }

        public IList<Animal> Animal { get;set; }

        public IActionResult OnGet()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return new RedirectToPageResult("Animal");
            }
            return Page();
        }
    }
}
