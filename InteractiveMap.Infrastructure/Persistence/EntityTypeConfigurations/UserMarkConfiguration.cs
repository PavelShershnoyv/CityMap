using InteractiveMap.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InteractiveMap.Infrastructure.Persistence.EntityTypeConfigurations;

public class UserMarkConfiguration : IEntityTypeConfiguration<UserMark>
{
    public void Configure(EntityTypeBuilder<UserMark> builder)
    {
        builder.ToTable("UserMarks");

        builder.OwnsOne(mark => mark.Position);
    }
}
