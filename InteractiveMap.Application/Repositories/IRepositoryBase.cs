using System.Linq.Expressions;
using InteractiveMap.Core.Entities.Base;

namespace InteractiveMap.Application.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    void Update(TEntity entity);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    void Delete(TEntity entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
