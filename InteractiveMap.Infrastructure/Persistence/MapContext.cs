using System.Reflection;
using InteractiveMap.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Infrastructure.Persistence;

public class MapContext : DbContext
{
    public DbSet<Mark> Marks { get; set; }

    public DbSet<UserMark> UserMarks { get; set; }

    public DbSet<MarkImage> MarkImages { get; set; }

    public DbSet<MapLayer> MapLayers { get; set; }

    public DbSet<UserMapLayer> UserMapLayers { get; set; }

    public MapContext() : base() { }

    public MapContext(DbContextOptions<MapContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
