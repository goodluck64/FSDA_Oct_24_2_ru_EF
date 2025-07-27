using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore1.Entities;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public double Price { get; set; }

    public Publisher Publisher { get; set; } = null!; // virtual for lazy loading
    public int PublisherId { get; set; }

    public ICollection<Category> Categories { get; set; } = [];  // virtual for lazy loading
}