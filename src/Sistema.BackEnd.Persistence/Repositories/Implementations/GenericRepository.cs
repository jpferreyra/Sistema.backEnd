using Sistema.BackEnd.Persistence.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sistema.BackEnd.Persistence.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SistemaDbContext _DbContext;
        protected readonly DbSet<T> _entities;

        public GenericRepository(SistemaDbContext context)
        {
            _DbContext = context;
            _entities = context.Set<T>();
        }

        public async Task<int> CountAsync()
        {
            return await _entities.CountAsync();
        }

        public async Task DeleteAsync(int Id)
        {

            T Entity = await GetByIdAsync(Id);
            _entities.Remove(Entity);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entities.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> whereCondition = null,
                                            Func<IQueryable<T>,
                                            IOrderedQueryable<T>> orderBy = null,
                                            string includeProperties = "")
        {
            IQueryable<T> query = _entities;

            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<T> GetByIdAsync(int id) => await _DbContext.Set<T>().FindAsync(id);


        public async Task InsertAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }
    }
}
