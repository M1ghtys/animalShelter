using iis.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace iis.Facades
{
    public class WalkFacade
    {
        private readonly iis.Data.iisContext _context;

        public WalkFacade(iis.Data.iisContext context)
        {
            _context = context;
        }

        public bool WalkExists(int? id)
        {
            return _context.Walk.Any(e => e.Id == id);
        }
    }
}