using InteractiveMap.Core.Entities;

namespace InteractiveMap.Application.Repositories;

public interface IMapLayerRepository<TMapLayer> : IRepositoryBase<TMapLayer> where TMapLayer : BaseMapLayer
{
}
