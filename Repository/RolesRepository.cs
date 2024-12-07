using GestionDeAulas.Models;
using Microsoft.AspNetCore.Identity;

namespace GestionDeAulas.Repository
{
    public class RolesRepository:Repository<IdentityRole>
    {
        public RolesRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
