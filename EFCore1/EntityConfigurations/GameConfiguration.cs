using EFCore1.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore1.EntityConfigurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasMaxLength(NameMaxLength);
        builder.HasIndex(e => e.Name).IsUnique();
    }
    
    private const int NameMaxLength = 450;
}