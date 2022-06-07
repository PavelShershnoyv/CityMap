using InteractiveMap.Core.Entities;

namespace InteractiveMap.Application.Repositories;

public interface IMarkRepository<TMark> : IRepositoryBase<TMark> where TMark : BaseMark
{

}
