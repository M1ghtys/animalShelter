using System;
using iis.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace iis.Facades
{
    public class WalkFacade
    {
        private readonly iis.Data.DbContext _context;

        public WalkFacade(iis.Data.DbContext context)
        {
            _context = context;
        }

        public bool WalkExists(Guid? id)
        {
            return _context.Walk.Any(e => e.Id == id);
        }
    }
}