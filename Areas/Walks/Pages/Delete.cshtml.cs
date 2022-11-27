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
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace iis.Pages.Walks
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly iis.Data.DbContext _context;
        private readonly WalkFacade _facade;

        public DeleteModel(iis.Data.DbContext context)
        {
            _context = context;
            _facade = new WalkFacade(context);
        }

        [BindProperty]
        public Walk Walk { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || !_facade.WalkExists(id))
            {
                return NotFound();
            }

            Walk = await _context.Walk.FirstOrDefaultAsync(m => m.Id == id);
            Walk.User = await _context.Users.FirstOrDefaultAsync(m => m.Id == Walk.UserId.ToString());
            Walk.Animal = await _context.Animal.FirstOrDefaultAsync(m => m.Id == Walk.AnimalId);

            if (Walk == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || !_facade.WalkExists(id))
            {
                return NotFound();
            }

            Walk = await _context.Walk.FindAsync(id);

            if (Walk != null)
            {
                _context.Walk.Remove(Walk);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
