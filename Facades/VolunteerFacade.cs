using iis.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace iis.Facades
{
    public class VolunteerFacade
    {
        private readonly iis.Data.iisContext _context;

        public VolunteerFacade(iis.Data.iisContext context)
        {
            _context = context;
        }

        public bool VolunteerExists(int? id)
        {
            return _context.Volunteer.Any(e => e.Id == id);
        }
    }
}