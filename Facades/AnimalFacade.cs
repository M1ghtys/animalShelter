using iis.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace iis.Facades
{
    public class AnimalFacade
    {
        private readonly iis.Data.iisContext _context;

        public AnimalFacade(iis.Data.iisContext context)
        {
            _context = context;
        }

        public bool AnimalExists(int? id)
        {
            return _context.Animal.Any(e => e.Id == id);
        }
    }
}