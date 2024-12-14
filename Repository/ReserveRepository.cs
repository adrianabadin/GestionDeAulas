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
        public async Task Update(Reserve entity,string id)
        {
            var reserve = await Db.FindAsync(id);
            if (reserve != null)
            {
                reserve.Hour = entity.Hour;
                reserve.EndDate = entity.EndDate;
                reserve.Date = entity.Date;
                reserve.UserId = entity.UserId;
                reserve.RoomId = entity.RoomId;
                reserve.ClassId = entity.ClassId;
                reserve.Description = entity.Description;
                reserve.IsActive = entity.IsActive;
                reserve.TotalHours = entity.TotalHours;
                
                await Context.SaveChangesAsync();
            }


        }
        public async Task<ICollection<ClassRoom>> Seek(ReserveCreateVM entity,bool omitEntity =false) 
        {
            if (omitEntity == false) { 
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
            } else
            {
                var rooms = await Context.Classrooms
        .Where(room => room.IsActive && room.Seats >= entity.Students &&
                       room.Reserves.All(res => res.Id !=entity.Id ||
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
                return rooms;
            }

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
