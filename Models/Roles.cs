using Microsoft.AspNetCore.Identity;

namespace GestionDeAulas.Models
{
    public class Roles:IdentityRole
    {
        public virtual ICollection<IdentityUserRole<string>>? UserRoles { get; set; }
    }
}
