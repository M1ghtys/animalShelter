using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace iis.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<Walk> Walks { get; set; } = new Collection<Walk>();
    }
}
