using GestionDeAulas.Models;
using GestionDeAulas.Models.IModel;
using GestionDeAulas.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace GestionDeAulas.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly AppDbContext Context;
        protected readonly DbSet<T> Db;
        public Repository(AppDbContext context)
        {
            Context=context;
            Db=Context.Set<T>();
        }
        public void Add(T entity)
        {
            Db.Add(entity);
        }

        public async Task<T?> GetByID(string? id)
        {
            if (id == null) return await Db.FirstOrDefaultAsync();
            return await Db.FindAsync(id);
        }

        public async Task<T?> GetFirst(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = Db;
            if (filter != null) {
                query.Where(filter);
                    }
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char [] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(item);
                }
                {
                    
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<ICollection<T>> List(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeProperties = null)
        {
            IQueryable<T> query = Db;
            if (filter != null)
            {
                
                query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query =query.Include(item);
                }
                {

                }
            }
            if (orderBy != null) return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }
        private bool HasXProperty(string Choice) {
            Type type = typeof(T);
            var property = type.GetProperty(Choice, BindingFlags.Public | BindingFlags.Instance);
            if (property == null) return false;
            return true;
        }
        public async Task Remove(string id)
        {
            var entidad = await Db.FindAsync(id) as IActivable;
            if (entidad != null && HasXProperty("IsActive")) { 
                entidad.IsActive = false; }
        }
        public async Task UnDelete(string id)
        {
            var entidad = await Db.FindAsync(id) as IActivable;
            if (entidad != null && HasXProperty("IsActive"))
            {
                entidad.IsActive = true;
            }

        }
        public async Task Remove(T entity )
        {
            var entidad1 = entity as IActivable;
            if (entidad1 !=null && HasXProperty("Id") &&entidad1.Id != null && HasXProperty("IsActive")) { 
            var entidad = await Db.FindAsync(entidad1.Id) as IActivable;
            if (entidad != null) entidad.IsActive = false ;
            }

        }
    }
}
