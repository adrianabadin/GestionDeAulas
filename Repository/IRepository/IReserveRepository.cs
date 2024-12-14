using GestionDeAulas.Models;
using GestionDeAulas.Models.ViewModels.Reserves;

namespace GestionDeAulas.Repository.IRepository
{
    public interface IReserveRepository:IRepository<Reserve>
    {
        public Task Update(Reserve entity,string id);
        public Task<ICollection<ClassRoom>> Seek(ReserveCreateVM entity,bool omitEntity);
        public  Task<ICollection<User>> TeachersList(string roleId);
    }
}
