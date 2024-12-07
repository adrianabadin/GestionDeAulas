using GestionDeAulas.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeAulas.Repository
{
    public class UserRepository :Repository<User>
    {
     
        public UserRepository(AppDbContext Context):base(Context)
        {
        
        }
        public Task Update(User entity) {
            
            throw new NotImplementedException();
        }
    }
}
