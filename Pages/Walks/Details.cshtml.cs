﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using iis.Data;
using iis.Models;
using iis.Facades;

namespace iis.Pages.Walks
{
    public class DetailsModel : PageModel
    {
        private readonly iis.Data.iisContext _context;
        private readonly WalkFacade _facade;

        public DetailsModel(iis.Data.iisContext context)
        {
            _context = context;
            _facade = new WalkFacade(context);
        }

        public Walk Walk { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || !_facade.WalkExists(id))
            {
                return NotFound();
            }

            Walk = await _context.Walk.FirstOrDefaultAsync(m => m.Id == id);

            if (Walk == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
