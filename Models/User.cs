using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace iis.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
