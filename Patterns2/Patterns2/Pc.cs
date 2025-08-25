namespace Patterns2;

record Pc
{
    public Ram Ram { get; set; } = null!;
    public Gpu Gpu { get; set; } = null!;
    public Cpu Cpu { get; set; } = null!;
}