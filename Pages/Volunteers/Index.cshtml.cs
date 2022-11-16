using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using iis.Data;
using iis.Models;

namespace iis.Pages.Volunteers
{
    public class IndexModel : PageModel
    {
        private readonly iis.Data.iisContext _context;

        public IndexModel(iis.Data.iisContext context)
        {
            _context = context;
        }

        public IList<Volunteer> Volunteer { get;set; }

        public async Task OnGetAsync()
        {
            Volunteer = await _context.Volunteer.ToListAsync();
        }
    }
}
