using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using iis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;

namespace iis.Pages.Walks
{
    [Authorize(Roles = "Admin,Caretaker,Vet,VerifiedUser")]
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
            
            IList<Walk> walkOrder = _context.Walk.ToList();

            switch (sortOrder)
            {
                case "time_desc":
                    Walks = walkOrder.OrderByDescending(s => s.StartTime).ToList();
                    break;
                case "State":
                    Walks = walkOrder.OrderBy(s => s.State).ToList();
                    break;
                case "State_desc":
                    Walks = walkOrder.OrderByDescending(s => s.State).ToList();
                    break;
                default:
                    Walks = walkOrder.OrderBy(s => s.StartTime).ToList();
                    break;
            }
            
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
