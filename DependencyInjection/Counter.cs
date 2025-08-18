namespace DependencyInjection;

internal class Counter : ICounter
{
    private readonly ILogger _logger;

    public Counter(ILogger logger)
    {
        _logger = logger;
    }

    public void Increment()
    {
        _count++;

        _logger.Log("Counter::Increment:");
    }

    public int Count => _count;

    private int _count = 0;
}