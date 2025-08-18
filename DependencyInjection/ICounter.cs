namespace DependencyInjection;

internal interface ICounter
{
    void Increment();

    int Count { get; }
}