﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using iis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iis.Pages.Walks
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly iis.Data.DbContext _context;

        public IndexModel(iis.Data.DbContext context)
        {
            _context = context;
        }

        public string StartTimeSort { get; set; }
        public string FinishTimeSort { get; set; }
        public string StateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public IList<Walk> Walks { get;set; }
        

        public async Task OnGetAsync(string sortOrder)
        {
            
            StartTimeSort = String.IsNullOrEmpty(sortOrder) ? "time_desc" : "";
            StateSort = sortOrder == "State" ? "State_desc" : "State";

            IQueryable<Walk> walkOrder = from s in _context.Walk
                                         select s;

            switch (sortOrder)
            {
                case "time_desc":
                    walkOrder = walkOrder.OrderByDescending(s => s.StartTime);
                    break;
                case "State":
                    walkOrder = walkOrder.OrderBy(s => s.State);
                    break;
                case "State_desc":
                    walkOrder = walkOrder.OrderByDescending(s => s.State);
                    break;
                default:
                    walkOrder = walkOrder.OrderBy(s => s.StartTime);
                    break;
            }

            Walks = await walkOrder.AsNoTracking().ToListAsync();

            foreach (var w in Walks)
            {
                w.Animal = await _context.Animal.FirstOrDefaultAsync(a => a.Id == w.AnimalId);
                w.User = await _context.Users.FirstOrDefaultAsync(v => v.Id == w.UserId.ToString());
            }
        }

        public IActionResult OnPostCreate()
        {
            return RedirectToPage("Create");
        }
    }
}
