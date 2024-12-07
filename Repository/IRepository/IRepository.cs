using GestionDeAulas.Models;
using GestionDeAulas.Models.IModel;
using System.Linq.Expressions;

namespace GestionDeAulas.Repository.IRepository
{
    public interface IRepository<T> where T : class
                                    
    {
        public  Task<ICollection<T>> List(Expression<Func<T,bool>>? filter=null,Func<IQueryable<T>,IOrderedQueryable<T>>? orderBy=null,string? includeProperties =null);
        public Task<T?> GetByID(string? id);
        public Task<T?> GetFirst(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        public void Add(T entity);
        public Task Remove(string id);
        public Task Remove(T entity);
        public Task UnDelete(string id);

    }
}
