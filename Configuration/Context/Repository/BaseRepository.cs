using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace UnambaRepoApi.Configuration.Context.Repository;

public abstract class BaseRepository<TContext> : IBaseRepository where TContext : DbContext
{
    protected readonly TContext _context;

    protected BaseRepository(TContext context)
    {
        _context = context;
    }

    public async Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}
