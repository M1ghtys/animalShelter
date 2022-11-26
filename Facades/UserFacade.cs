using System;
using iis.Models;
using System.Linq;
using iis.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iis.Facades
{
    public class UserFacade
    {
        private readonly iis.Data.DbContext _context;
        private readonly UserManager<Models.User> _userManager;
        
        public UserFacade(iis.Data.DbContext context, UserManager<iis.Models.User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public bool UserExists(Guid? id)
        {
            return _context.Users.Any(e => e.Id == id.ToString());
        }

        public async Task<Role> GetUserRoleAsync(Guid? id)
        {
            var UserList = await _userManager.GetUsersInRoleAsync("UnverifiedUser");
            foreach (var u in UserList)
            {
                if (id.ToString() == u.Id) return Role.UnverifiedUser;
            }
            
            UserList = await _userManager.GetUsersInRoleAsync("VerifiedUser");
            foreach (var u in UserList)
            {
                if (id.ToString() == u.Id) return Role.VerifiedUser;
            }
            
            UserList = await _userManager.GetUsersInRoleAsync("Caretaker");
            foreach (var u in UserList)
            {
                if (id.ToString() == u.Id) return Role.Caretaker;
            }

            UserList = await _userManager.GetUsersInRoleAsync("Vet");
            foreach (var u in UserList)
            {
                if (id.ToString() == u.Id) return Role.Vet;
            }

            UserList = await _userManager.GetUsersInRoleAsync("Admin");
            foreach (var u in UserList)
            {
                if (id.ToString() == u.Id) return Role.Admin;
            }

            return Role.UnverifiedUser;
        }
    }
}
