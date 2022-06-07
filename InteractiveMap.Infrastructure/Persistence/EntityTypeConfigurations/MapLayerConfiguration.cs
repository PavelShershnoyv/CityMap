using InteractiveMap.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InteractiveMap.Infrastructure.Persistence.EntityTypeConfigurations;

internal class MapLayerConfiguration : IEntityTypeConfiguration<MapLayer>
{
    public void Configure(EntityTypeBuilder<MapLayer> builder)
    {
        builder.ToTable("MapLayers");
    }
}
