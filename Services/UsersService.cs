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
        public async Task<bool> Delete(User user) {
            var data = await _context.Users.FindAsync(user.Id);
            if (data == null) return false;
            data.IsActive = false;
            var response = _context.SaveChangesAsync();
            if (response == null) return false;
            return true;

        }
        public async Task<bool> Activate (User user)
        {
            var data = await _context.Users.FindAsync(user.Id);
            if (data == null) return false;
            data.IsActive = true;
            var response = _context.SaveChangesAsync();
            if (response == null) return false;
            return true;
        }
    }
}
