using System.Collections.Generic;

namespace iis.Data
{
    public enum Role
    {
        Admin,
        Caretaker,
        Veterinarian,
        Volunteer, 
        Unverified,
    }

    public static class Roles
    {
        private static readonly Dictionary<Role, string> _roles = new Dictionary<Role, string>()
        {
            { Role.Admin,  "Admin" },
            { Role.Caretaker, "Caretaker" },
            { Role.Veterinarian,  "Veterinarian" },
            { Role.Volunteer, "Volunteer" },
            { Role.Unverified, "Unverified" }
        };

        public static IReadOnlyDictionary<Role, string> GetRoles() => _roles;
    }
}
