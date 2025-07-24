using EFCore1.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore1.EntityConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasMaxLength(NameMaxLength);

        builder.HasMany(e => e.Games)
            .WithMany(e => e.Categories)
            .UsingEntity<CategoryGame>()
            .HasKey(e => new { e.CategoryId, e.GameId });
    }

    private const int NameMaxLength = 32;
}