using System.Linq.Expressions;
using ECommerceApp.Core;
using ECommerceApp.Core.Interfaces;
using ECommerceApp.Core.Models;
using ECommerceApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace ECommerceApp.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<Result<TEntity>> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return new Result<TEntity>(true, "Entity added successfully.", entity);
            }
            else
            {
                return new Result<TEntity>(false, "Failed to add entity.", entity);
            }
        }

        public async Task<Result<TEntity>> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return new Result<TEntity>(true, "Entity deleted successfully.", entity);
                }
                else
                {
                    return new Result<TEntity>(false, "Failed to delete entity.", entity!);
                }
            }
            else
            {
                return new Result<TEntity>(false, "Entity not found.", null!);
            }
        }

        public async Task<IQueryable<TEntity>> GetAllQueryAsync()
        {
            var query = _dbSet.AsQueryable();
            return await Task.FromResult(query);
        }
        public async Task<Result<IEnumerable<TEntity>>> GetFilteredAsync(Expression<Func<TEntity, bool>> filter = null!)
        {
            var query = await GetAllQueryAsync();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var entities = await query.ToListAsync();
            if (entities.Any())
            {
                return new Result<IEnumerable<TEntity>>(true, "Filtered entities retrieved successfully.", entities);
            }
            else
            {
                return new Result<IEnumerable<TEntity>>(false, "Filtered entities retrieved successfully.", null);
            }
        }
        public async Task<Result<IEnumerable<TEntity>>> GetAllAsync()
        {
            var entities = await _dbSet.ToListAsync();
            return new Result<IEnumerable<TEntity>>(true, "Entities retrieved successfully.", entities);
        }
        public async Task<Result<IEnumerable<TEntity>>> GetAllInculedeAsync(Expression<Func<TEntity, bool>> filter = null!, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            var entities = await query.ToListAsync();

            return new Result<IEnumerable<TEntity>>(true, "Entities with included related data retrieved successfully.", entities);
        }
        public async Task<Result<IEnumerable<TEntity>>> GetAllInculedeThenInculudeveAsync(
            Expression<Func<TEntity, bool>> filter = null!,
            params (Expression<Func<TEntity, object>> include, Expression<Func<object, object>>[] thenIncludes)[] includes)
        {
            var query = _dbSet.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var (include, thenIncludes) in includes)
            {
                var includedQuery = query.Include(include);

                if (thenIncludes != null)
                {
                    foreach (var thenInclude in thenIncludes)
                    {
                        includedQuery = includedQuery.ThenInclude(thenInclude);
                    }
                }

                query = includedQuery;
            }

            var entities = await query.ToListAsync();

            return new Result<IEnumerable<TEntity>>(true, "Entities with included related data retrieved successfully.", entities);
        }
        public async Task<Result<TEntity>> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                return new Result<TEntity>(true, "Entity found.", entity);
            }
            else
            {
                return new Result<TEntity>(false, "Entity not found.", null!);
            }
        }
        public async Task<Result<TEntity>> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return new Result<TEntity>(true, "Entity updated successfully.", entity);
            }
            else
            {
                return new Result<TEntity>(false, "Failed to update entity.", entity);
            }
        }


    }
}
