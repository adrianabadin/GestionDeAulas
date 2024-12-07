using GestionDeAulas.Models;

namespace GestionDeAulas.Repository.IRepository
{
    public interface IClassRoomRepository : IRepository<ClassRoom>
    {
        public Task Update(ClassRoom entity);
    }
}
