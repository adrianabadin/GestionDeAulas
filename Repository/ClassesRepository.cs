using GestionDeAulas.Models;
using GestionDeAulas.Models.DTOs;
using GestionDeAulas.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace GestionDeAulas.Repository
{
    public class ClassesRepository : Repository<Classes>, IClassesRepository

    {
       // public AppDbContext Context;
        public ClassesRepository(AppDbContext context) :base(context)
        {
         //   Context = context;
        }
        public async Task Update(Classes entity)
        {
            var classEntity = await Db.FindAsync(entity.Id);
            if (classEntity == null) throw new Exception("Class Not Found");
            classEntity.Name = entity.Name ?? classEntity.Name;
            classEntity.Description = entity.Description?? classEntity.Description;
            classEntity.CourseId = entity.CourseId !=null  ?entity.CourseId :classEntity.CourseId ;
            classEntity.UserId= entity.UserId ?? classEntity.UserId;
            classEntity.IsActive = entity.IsActive ==null ?  classEntity.IsActive : entity.IsActive;
            
        }
        public async Task<ICollection<NamedEntity>> GetTeachers() {
            var teacherId = await Context.Roles.Where(rol => rol.NormalizedName == "DOCENTE").Select(role=>role.Id).FirstAsync();
            if (teacherId == null) throw new Exception("El rol DOCENTE no existe");
            var response = await Context.Users
                .Include(user => user.MyUserRoles)
                .Where(user => user.IsActive == true && (user.MyUserRoles
                    .First(us => us.RoleId == teacherId) != null) )
                .Select(user => new NamedEntity() { Id = user.Id, Name = user.FirstName + " " + user.LastName })
                .ToListAsync();
            return response;
        }

        public async Task<ICollection< NamedEntity>> GetCourses()
        {
            var response = await  Context.Courses
                .Where(i => i.IsActive == true)
                .Select(i => new NamedEntity() { Id = i.Id, Name = i.Name })
                .ToListAsync();
            return response;
        }
    }
}
