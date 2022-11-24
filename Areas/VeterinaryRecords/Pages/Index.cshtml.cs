using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using iis.Data;
using iis.Models;

namespace iis.Pages.VeterinaryRecords
{
    public class IndexModel : PageModel
    {
        private readonly iis.Data.DbContext _context;

        public IndexModel(iis.Data.DbContext context)
        {
            _context = context;
        }

        public IList<VeterinaryRecord> VeterinaryRecord { get;set; }

        public async Task OnGetAsync()
        {
            VeterinaryRecord = await _context.VeterinaryRecord.ToListAsync();
        }
    }
}
