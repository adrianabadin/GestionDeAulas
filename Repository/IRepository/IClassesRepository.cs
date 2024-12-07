using GestionDeAulas.Models;
using GestionDeAulas.Models.DTOs;
using GestionDeAulas.Models.ViewModels.Classes;

namespace GestionDeAulas.Repository.IRepository
{
    public interface IClassesRepository :IRepository<Classes>
    {
        public Task Update(Classes entity);
        public Task<ICollection<NamedEntity>> GetTeachers();
        public Task<ICollection<NamedEntity>> GetCourses();
    }
}
