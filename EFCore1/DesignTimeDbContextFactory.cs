using Microsoft.EntityFrameworkCore.Design;

namespace EFCore1;

internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args) =>
        new(new ConfigurationBuilder().AddJsonFile("config.json").Build(), true);
}