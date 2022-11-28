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
        public string CurrentFilterV { get; set; }
        public IList<Walk> Walks { get;set; }

        public async Task<IActionResult> OnGetAsync(int? order, string search)
        {
            int orderBy = order.HasValue ? order.Value : 0;

            string searchParams = search == null ? string.Empty : search.ToLower();

            return await LoadData(orderBy, searchParams);
        }

        private async Task<IActionResult> LoadData(int order, string search)
        {
            var walks = _context.Walk.ToList();

            foreach (var v in walks)
            {
                v.Animal = await _context.Animal.FirstOrDefaultAsync(a => a.Id == v.AnimalId);
                v.User = await _context.Users.FirstOrDefaultAsync(a => a.Id == v.UserId.ToString());
            }

            walks = walks.Where(v => v.Animal.Name.ToLower().Contains(search)).ToList();

            switch (order)
            {
                case 1:
                    Walks = walks.OrderBy(n => n.User.Name).ToArray();
                    break;
                case -1:
                    Walks = walks.OrderByDescending(n => n.User.Name).ToArray();
                    break;
                case 2:
                    Walks = walks.OrderBy(n => n.StartTime).ToArray();
                    break;
                case -2:
                    Walks = walks.OrderByDescending(n => n.StartTime).ToArray();
                    break;
                case 3:
                    Walks = walks.OrderBy(n => n.Animal.Name).ToArray();
                    break;
                case -3:
                    Walks = walks.OrderByDescending(n => n.Animal.Name).ToArray();
                    break;
                default:
                    Walks = walks.ToArray();
                    break;
            }

            return Page();
        }

        public IActionResult OnPostCreate()
        {
            return RedirectToPage("Create");
        }

        public async Task<IActionResult> OnPostReserveAsync(string walkId)
        {
            if(walkId == null)
            {
                throw new Exception("Error occured whilst loading data");
            }
            var userId = _context.Users.FirstOrDefaultAsync(x => x.UserName == User.Identity.Name).Result.Id;
            var walk = await _context.Walk.FirstOrDefaultAsync(x => x.Id == Guid.Parse(walkId));
            walk.UserId = Guid.Parse(userId);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostVerifyAsync(string walkId)
        {
            if (walkId == null)
            {
                throw new Exception("Error occured whilst loading data");
            }

            var walk = await _context.Walk.FirstOrDefaultAsync(x => x.Id == Guid.Parse(walkId));
            walk.IsVerified = true;
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
