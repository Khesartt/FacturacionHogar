using System.Linq.Expressions;
using FacturacionHogar.Infraestructure.Context;
using FacturacionHogar.Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;

public class DefaultEntityFrameworkRepository<TEntity> : IDefaultRepository<TEntity> where TEntity : class
{
    protected readonly ApiContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public DefaultEntityFrameworkRepository(ApiContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await this._dbSet.ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        await SaveChangesAsync();
    }

    public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await SaveChangesAsync();
    }

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task<int> CountAsync()
    {
        return await _dbSet.CountAsync();
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.CountAsync(predicate);
    }

    public async Task<bool> ExistsAsync(object id)
    {
        return await GetByIdAsync(id) != null;
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TEntity>> GetPagedAsync(int pageNumber, int pageSize)
    {
        return await _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
    }
}
