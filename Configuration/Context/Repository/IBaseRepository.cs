using System.Linq.Expressions;

namespace UnambaRepoApi.Configuration.Context.Repository;

public interface IBaseRepository
{
    Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
    Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class;
    Task AddAsync<TEntity>(TEntity entity) where TEntity : class;
    Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;
    Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class;
}