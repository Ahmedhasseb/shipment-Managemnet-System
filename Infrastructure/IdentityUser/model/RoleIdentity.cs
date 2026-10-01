using Microsoft.AspNetCore.Identity;

namespace Infrastructure.IdentityUser.model
{
    public class RoleIdentity : IdentityRole
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
