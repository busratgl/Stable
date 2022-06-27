using Microsoft.EntityFrameworkCore;
using Stable.Core.Entities.Abstract;
using Stable.Repository.Abstract;
using Stable.Repository.Concrete.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stable.Repository.Concrete.EntityFramework
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity, new()
    {
        private readonly StableDbContext _stableDbContext;

        public BaseRepository(StableDbContext stableDbContext)
        {
            _stableDbContext = stableDbContext;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _stableDbContext.Set<T>();

            return await query.SingleOrDefaultAsync(expression);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await _stableDbContext.Set<T>().CountAsync(expression);
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => { _stableDbContext.Set<T>().Remove(entity); });

        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            IQueryable<T> query = _stableDbContext.Set<T>();
            if (expression != null)
            {
                query = query.Where(expression);
            }

            return await query.ToListAsync();
        }
        public async Task CreateAsync(T entity)
        {
            await _stableDbContext.Set<T>().AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => { _stableDbContext.Set<T>().Update(entity); });
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _stableDbContext.Set<T>().AnyAsync(expression);
        }


    }
}
