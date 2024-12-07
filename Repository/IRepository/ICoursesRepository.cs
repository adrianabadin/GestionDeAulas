using GestionDeAulas.Models;

namespace GestionDeAulas.Repository.IRepository
{
    public interface ICoursesRepository :IRepository<Course>
    {
        public Task Update(Course entity);
    }
}
