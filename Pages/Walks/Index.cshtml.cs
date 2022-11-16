using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using iis.Data;
using iis.Models;

namespace iis.Pages.Walks
{
    public class IndexModel : PageModel
    {
        private readonly iis.Data.iisContext _context;

        public IndexModel(iis.Data.iisContext context)
        {
            _context = context;
        }

        public IList<Walk> Walk { get;set; }

        public async Task OnGetAsync()
        {
            Walk = await _context.Walk.ToListAsync();
        }
    }
}
