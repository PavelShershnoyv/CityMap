using System.Linq.Expressions;
using InteractiveMap.Application.Repositories;
using InteractiveMap.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Infrastructure.Persistence.Repositories;

public abstract class BaseRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _set;

    public BaseRepository(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _set = context.Set<TEntity>();
    }

    public virtual async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return (await _set.AddAsync(entity, cancellationToken)).Entity;
    }

    public IQueryable<TEntity> GetAll()
    {
        return _set.AsNoTracking();
    }

    public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
    {
        return _set.Where(predicate).AsNoTracking();
    }

    public virtual async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _set.FirstOrDefaultAsync(nextEntity => nextEntity.Id == id, cancellationToken);
    }

    public virtual void Update(TEntity entity)
    {
        _set.Update(entity);
    }

    public virtual async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(id, cancellationToken);

        Delete(entity);
    }

    public virtual void Delete(TEntity entity)
    {
        _set.Remove(entity);
    }

    public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}

