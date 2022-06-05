using System.Reflection;
using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Infrastructure.Persistence;

public class MapContext : DbContext, IMapContext
{
    public DbSet<MarkType> MarkTypes => Set<MarkType>();

    public DbSet<UserMark> UserMarks => Set<UserMark>();

    public DbSet<Mark> PublicMarks => Set<Mark>();

    public DbSet<MapLayer> PublicMapLayers => Set<MapLayer>();

    public DbSet<UserMapLayer> UserMapLayers => Set<UserMapLayer>();

    public MapContext() : base() { }

    public MapContext(DbContextOptions<MapContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
