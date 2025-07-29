namespace EFCore1.Entities;

public class EarlyAccessGame : Game
{
    public DateTime ReleaseDate { get; set; }
    public int VoteUp { get; set; }
    public int VoteDown { get; set; }
}