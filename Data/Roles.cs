using System.Collections.Generic;

namespace iis.Data
{
    public enum Role
    {
        Admin,
        Caretaker,
        Vet,
        VerifiedUser,
        UnverifiedUser
    }

    public static class Roles
    {
        private static readonly Dictionary<Role, string> _roles = new Dictionary<Role, string>()
        {
            { Role.Admin,  "Admin" },
            { Role.Caretaker,  "Caretaker" },
            { Role.Vet, "Vet" },
            { Role.VerifiedUser, "VerifiedUser" },
            { Role.UnverifiedUser, "UnverifiedUser" }
        };

        public static IReadOnlyDictionary<Role, string> GetRoles() => _roles;
    }
}
