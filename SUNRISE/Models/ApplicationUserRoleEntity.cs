using Microsoft.AspNetCore.Identity;

namespace SUNRISE.Models
{
    public class ApplicationUserRoleEntity : IdentityRole
    {
        public ApplicationUserRoleEntity() : base() { }

        public ApplicationUserRoleEntity(string name) : base(name) { }
    }
}
