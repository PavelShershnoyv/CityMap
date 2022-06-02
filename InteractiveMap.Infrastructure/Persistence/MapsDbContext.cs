using InteractiveMap.Application.Common.Interfaces;
using InteractiveMap.Core.Entities;
using InteractiveMap.Infrastructure.Persistence.EntityTypeConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Infrastructure.Persistence;

public class MapsDbContext : IdentityDbContext, IMapsDbContext
{
    public DbSet<UserMark> UserMarks => Set<UserMark>();

    public DbSet<Mark> PublicMarks => Set<Mark>();

    public DbSet<MarkType> MarkTypes => Set<MarkType>();

    public DbSet<MapLayer> PublicMapLayers => Set<MapLayer>();

    public DbSet<UserMapLayer> UserMapLayers => Set<UserMapLayer>();

    public MapsDbContext() : base() { }

    public MapsDbContext(DbContextOptions<MapsDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new MapLayerConfiguration());
        builder.ApplyConfiguration(new UserMapLayerConfiguration());
    }
}
