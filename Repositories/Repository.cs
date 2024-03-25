
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Repositories.Interfaces;

namespace EMS.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        /*** Properties ***/
        private readonly AppDbContext _db;
        internal DbSet<T> _dbSet;

        /*** Constructor ***/
        public Repository(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        /*** Methods ***/
        public async Task<IEnumerable<T>> GetAll(List<string>? propsInclude = null)
        {
            IQueryable<T> query = _dbSet;
            if (propsInclude != null && propsInclude.Count != 0)
            {
                foreach (string prop in propsInclude)
                {
                    /* Eager Loading */
                    query = query.Include(prop);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T?> Get(Expression<Func<T, bool>> filter, List<string>? propsInclude = null)
        {
            // IEnumerable is typically used for querying in-memory collections, such as arrays, lists, or collections.
            // IQueryable is used for querying data from external data sources like databases, web services, or other data providers.
            IQueryable<T> query = _dbSet;
            if (propsInclude != null && propsInclude.Count != 0)
            {
                foreach (string prop in propsInclude)
                {
                    /* Eager Loading */
                    query = query.Include(prop);
                }
            }

            return await _dbSet.FirstOrDefaultAsync(filter);
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}