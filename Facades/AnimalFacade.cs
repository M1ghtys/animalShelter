using System;
using iis.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace iis.Facades
{
    public class AnimalFacade
    {
        private readonly iis.Data.DbContext _context;

        public AnimalFacade(iis.Data.DbContext context)
        {
            _context = context;
        }

        public bool AnimalExists(Guid? id)
        {
            return _context.Animal.Any(e => e.Id == id);
        }
    }
}