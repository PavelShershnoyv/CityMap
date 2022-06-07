using InteractiveMap.Application.Repositories;
using InteractiveMap.Core.Entities;

namespace InteractiveMap.Infrastructure.Persistence.Repositories;

public class MarkImageRepository : BaseRepository<MarkImage>, IMarkImageRepository
{
    public MarkImageRepository(MapContext context) : base(context)
    {
    }
}
