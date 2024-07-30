using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ECommerceApp.Core.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<Result<TEntity>> AddAsync(TEntity entity);
        Task<Result<TEntity>> DeleteAsync(int id);
        Task<Result<IEnumerable<TEntity>>> GetAllAsync();
        Task<Result<IEnumerable<TEntity>>> GetAllInculedeAsync(Expression<Func<TEntity, bool>> filter = null!, params Expression<Func<TEntity, object>>[] includes);
        Task<Result<TEntity>> GetByIdAsync(int id);
        Task<Result<TEntity>> UpdateAsync(TEntity entity);
        Task<IQueryable<TEntity>> GetAllQueryAsync();
        Task<Result<IEnumerable<TEntity>>> GetAllInculedeThenInculudeveAsync(
            Expression<Func<TEntity, bool>> filter = null!,
            params (Expression<Func<TEntity, object>> include, Expression<Func<object, object>>[] thenIncludes)[] includes);
    }

}