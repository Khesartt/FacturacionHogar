using System.Linq.Expressions;

namespace FacturacionHogar.Infraestructure.Interfaces
{
    public interface IDefaultRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(object id);

        Task<TEntity> AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task DeleteAsync(TEntity entity);

        Task DeleteRangeAsync(IEnumerable<TEntity> entities);

        Task UpdateAsync(TEntity entity);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> CountAsync();

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        Task<bool> ExistsAsync(object id);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);

        Task SaveChangesAsync();

        Task<IEnumerable<TEntity>> GetPagedAsync(int pageNumber, int pageSize);
    }
}
