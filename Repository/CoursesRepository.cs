using GestionDeAulas.Models;
using GestionDeAulas.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestionDeAulas.Repository
{
    public class CoursesRepository : Repository<Course>, ICoursesRepository
    {
        public CoursesRepository(AppDbContext Context):base(Context)
        {
            
        }
        public async Task Update(Course entity)
        {
            var response = await Db.FindAsync(entity.Id);
            if (response == null) throw new Exception("No se encuentra la carrera");
            response.Description = entity.Description ?? response.Description;
            response.IsActive = entity.IsActive ?? response.IsActive;
            response.Name = entity.Name ?? response.Name;
            response.InstitutionId=entity.InstitutionId ?? response.InstitutionId;
            response.StartingYear=entity.StartingYear ?? response.StartingYear;
            await Context.SaveChangesAsync();

        }
    }
}
