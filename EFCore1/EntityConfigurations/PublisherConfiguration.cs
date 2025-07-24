using EFCore1.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore1.EntityConfigurations;

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name)
            .HasMaxLength(PublisherNameMaxLength);

        builder.HasMany(e => e.Games)
            .WithOne(e => e.Publisher);
    }

    private const int PublisherNameMaxLength = 30;
}