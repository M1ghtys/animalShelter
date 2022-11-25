using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using iis.Models;
using Microsoft.AspNetCore.Authorization;

namespace iis.Pages.Walks   //TODO => změnit namespaces??
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly iis.Data.DbContext _context;

        public IndexModel(iis.Data.DbContext context)
        {
            _context = context;
        }

        public IList<Walk> Walks { get;set; }

        public async Task OnGetAsync()
        {
            Walks = await _context.Walk.ToListAsync();
            foreach (var w in Walks)
            {
                w.Animal = await _context.Animal.FirstOrDefaultAsync(a => a.Id == w.AnimalId);
                //w.Volunteer = await _context.Volunteer.FirstOrDefaultAsync(v => v.Id == w.VolunteerId);   //TODO Volunteer dědí z Usera Id typu GUID!? => změnit všechny Id na Guid??
            }
        }
    }
}
