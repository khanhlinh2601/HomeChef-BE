using HC.Application.Common.Interfaces;
using HC.Domain.Common;
using HC.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HC.Infrastructure.Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }
        public virtual async Task<T> GetOneByConditionAsync(Func<T, bool> expression)
        {
            return await Task.FromResult(dbSet.Where(expression).FirstOrDefault());
        }

        public virtual async Task<T> GetOneByConditionAsync(Func<T, bool> expression, Expression<Func<T, object>>[]? includeProperties = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await Task.FromResult(query.Where(expression).FirstOrDefault());
        }

        public virtual async Task<T> GetOneByConditionAsync(Guid id, Expression<Func<T, object>>[]? includeProperties = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await Task.FromResult(query.Where(x => x.Id.Equals(id)).FirstOrDefault());
        }

        //include
        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>>[]? includeProperties = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<int> CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            int rowEffect = await _context.SaveChangesAsync();
            return rowEffect;
        }

        public async Task<T> DeleteAsync(Guid id)
        {
            T _entity = await GetByIdAsync(id);
            if (_entity == null)
            {
                return null;
            }
            dbSet.Remove(_entity);
            await _context.SaveChangesAsync();
            return _entity;

        }

        public async Task<T> DeleteSoftAsync(Guid id)
        {
            T _entity = await GetByIdAsync(id);
            if (_entity == null)
            {
                return null;
            }
            _entity.IsDeleted = true;
            await UpdateAsync(_entity);
            return _entity;
        }

        public async Task<T> FindWithCondition(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id.Equals(id));
            return entity;
        }

        

        public async Task<int> UpdateAsync(T entity)
        {
            _context.Attach(entity).State = EntityState.Modified;
            int rowsEffect = await _context.SaveChangesAsync();
            return rowsEffect;
        }

        public async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
        {
            List<T> list;
            var query = dbSet.AsQueryable();
            foreach (var property in navigationProperties)
            {
                query = query.Include(property);
            }
            list = await query.Where(predicate).AsNoTracking().ToListAsync();
            return list;
        }

        public async Task<T> FindByIdAsync(Guid id, params string[] navigationProperties)
        {
            var query = ApplyNavigation(navigationProperties);
            T entity = await query.FirstOrDefaultAsync(e => e.Id.Equals(id));
            return entity;
        }

        private IQueryable<T> ApplyNavigation(params string[] navigationProperties)
        {
            var query = dbSet.AsQueryable();
            foreach (string navigationProperty in navigationProperties)
                query = query.Include(navigationProperty);
            return query;
        }


        public async Task<IEnumerable<T>> FindAllWithCondition(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await dbSet.AsNoTracking().ToListAsync();
            }
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllActiveAsync()
        {
            return await dbSet.AsNoTracking().Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<T> GetByIdActiveAsync(Guid id)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.Id.Equals(id) && x.IsDeleted == false);
        }

        public async Task<int> CountAsync()
        {
            return await dbSet.CountAsync();
        }
    }

}
