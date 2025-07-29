using EFCore1.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore1.EntityConfigurations;

public class EarlyAccessGameConfiguration : IEntityTypeConfiguration<EarlyAccessGame>
{
    public void Configure(EntityTypeBuilder<EarlyAccessGame> builder)
    {
        //builder.UseTptMappingStrategy();
    }
}