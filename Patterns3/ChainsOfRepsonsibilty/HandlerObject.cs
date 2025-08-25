namespace Patterns3.ChainsOfRepsonsibilty;

sealed class HandlerObject<T>
{
    public required T Data { get; set; }
    public IHandler<T>? LastHandler { get; set; }
}