using InteractiveMap.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InteractiveMap.Infrastructure.Persistence.EntityTypeConfigurations;

public class MarkConfiguration : IEntityTypeConfiguration<Mark>
{
    public void Configure(EntityTypeBuilder<Mark> builder)
    {
        builder.ToTable("Marks");

        builder.OwnsOne(mark => mark.Position);
    }
}
