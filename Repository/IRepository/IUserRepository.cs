using GestionDeAulas.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeAulas.Repository.IRepository
{
    public interface IUserRepository:IRepository<User>
    {
        public Task Update(User Entity);
    }
}
