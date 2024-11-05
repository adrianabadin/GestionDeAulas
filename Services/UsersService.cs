using GestionDeAulas.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeAulas.Services
{
    public class UsersService
    {
        private AppDbContext _context;
        public UsersService(AppDbContext context)
        {
            _context= context;
        }
        public async Task<IEnumerable<User>> List() {
            var response = await _context.Users.ToListAsync();
            return response;
        }
    }
}
