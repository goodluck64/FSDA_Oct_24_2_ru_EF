namespace EFCore1.Entities;

public class CategoryGame
{
    public Category Category { get; set; } = null!;
    public int CategoryId { get; set; }

    public Game Game { get; set; } = null!;
    public int GameId { get; set; }
}