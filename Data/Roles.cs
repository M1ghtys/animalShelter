using System.Collections.Generic;

namespace iis.Data
{
    public enum Role
    {
        Admin,
        Worker,
        Volunteer
    }

    public static class Roles
    {
        private static readonly Dictionary<Role, string> _roles = new Dictionary<Role, string>()
        {
            { Role.Admin,  "Admin" },
            { Role.Worker,  "Worker" },
            { Role.Volunteer, "Volunteer" },
        };

        public static IReadOnlyDictionary<Role, string> GetRoles() => _roles;
    }
}
