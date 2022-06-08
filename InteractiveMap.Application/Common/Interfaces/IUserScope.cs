using InteractiveMap.Core.Entities.Base;

namespace InteractiveMap.Application.Common.Interfaces;

public interface IUserScope<TEntity> where TEntity : BaseEntity
{
    Task<bool> CanUserReadAsync(Guid userId, TEntity entity);
    Task<bool> CanUserWriteAsync(Guid userId, TEntity entity);
}
