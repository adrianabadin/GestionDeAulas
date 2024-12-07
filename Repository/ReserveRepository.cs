using GestionDeAulas.Models;
using GestionDeAulas.Models.ViewModels.Reserves;
using GestionDeAulas.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace GestionDeAulas.Repository
{
    public class ReserveRepository : Repository<Reserve>, IReserveRepository
    {
        public ReserveRepository(AppDbContext Context) :base(Context)
        {
        }
        public Task Update(Reserve entity)
        {
            throw new NotImplementedException();
        }
        public async Task<ICollection<ClassRoom>> Seek(ReserveCreateVM entity) 
        {
            var rooms = await Context.Classrooms
    .Where(room => room.IsActive && room.Seats >= entity.Students &&
                   room.Reserves.All(res =>
                       !((
                            (entity.Date >= res.Date && entity.Date <= res.EndDate) ||
                            (entity.EndDate >= res.Date && entity.EndDate <= res.EndDate) ||
                            (entity.Date <= res.Date && entity.EndDate >= res.EndDate)
                        ) &&
                        (
                            (entity.Hour >= res.Hour && entity.Hour <= res.Hour + res.TotalHours) ||
                            (entity.Hour < res.Hour && entity.Hour + entity.TotalHours > res.Hour) ||
                            (entity.Hour <= res.Hour && entity.Hour + entity.TotalHours >= res.Hour + res.TotalHours)
                        )
                    )
                )
            )
        .ToListAsync();
            return  rooms;
        }
        public async Task<ICollection<User>> TeachersList(string roleId) {
            var response = Context.Users
        .Include(role => role.MyUserRoles)
        .Where(user => user.IsActive==true && 
        (user.MyUserRoles.First(users => users.RoleId == roleId) !=null)
        );
            Console.WriteLine(response.ToQueryString());
            return await response.ToListAsync();
        
        }
    }
}
