using System;
using iis.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace iis.Facades
{
    public class VeterinaryRecordFacade
    {
        private readonly iis.Data.DbContext _context;

        public VeterinaryRecordFacade(iis.Data.DbContext context)
        {
            _context = context;
        }

        public bool VeterinaryRecordExists(Guid? id)
        {
            return _context.VeterinaryRecord.Any(e => e.Id == id);
        }
    }
}