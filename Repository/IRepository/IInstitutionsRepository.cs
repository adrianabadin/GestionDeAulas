using GestionDeAulas.Models;

namespace GestionDeAulas.Repository.IRepository
{
    public interface IInstitutionsRepository:IRepository<Institutions>
    {
        public Task<Institutions> Update(Institutions entity);
    }
}
