using InteractiveMap.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InteractiveMap.Infrastructure.Persistence.EntityTypeConfigurations;

public class UserMapLayerConfiguration : IEntityTypeConfiguration<UserMapLayer>
{
    public void Configure(EntityTypeBuilder<UserMapLayer> builder)
    {
        builder.ToTable("UserMapLayers");
    }
}
