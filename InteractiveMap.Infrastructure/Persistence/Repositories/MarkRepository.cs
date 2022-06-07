using InteractiveMap.Application.Repositories;
using InteractiveMap.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Infrastructure.Persistence.Repositories;

public class MarkRepository<TMark> : BaseRepository<TMark>, IMarkRepository<TMark> where TMark : BaseMark
{
    public MarkRepository(MapContext context) : base(context) { }

    public override async Task<TMark> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _set
            .Include(mark => mark.Images)
            .FirstOrDefaultAsync(mark => mark.Id == id, cancellationToken);
    }
}
