using ORMS.Entities;

namespace ORMS;

internal class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:SqlServer"]);
    }

    public DbSet<Game> Games { get; set; }
}