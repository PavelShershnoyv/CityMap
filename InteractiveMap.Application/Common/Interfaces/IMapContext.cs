using InteractiveMap.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Application.Common.Interfaces;

public interface IMapContext
{
    DbSet<MarkType> MarkTypes { get; }
    DbSet<Mark> PublicMarks { get; }
    DbSet<UserMark> UserMarks { get; }
    DbSet<MapLayer> PublicMapLayers { get; }
    DbSet<UserMapLayer> UserMapLayers { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
