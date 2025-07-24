namespace EFCore1.Entities;

public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Game> Games { get; set; } = [];
}