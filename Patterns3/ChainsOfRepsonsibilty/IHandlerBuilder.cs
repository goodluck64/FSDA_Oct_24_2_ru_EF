namespace Patterns3.ChainsOfRepsonsibilty;

interface IHandlerBuilder<T>
{
    void AddHandler(IHandler<T> handler);

    IHandler<T> Build();
}

class HandlerBuilder<T> : IHandlerBuilder<T>
{
    private List<IHandler<T>> _handlers = new List<IHandler<T>>();

    public void AddHandler(IHandler<T> handler)
    {
        _handlers.Add(handler);
    }

    public IHandler<T> Build()
    {
        if (_handlers.Count == 0)
        {
            throw new InvalidOperationException("There must be at least one handler.");
        }

        IHandler<T>? last = null;

        foreach (var handler in _handlers)
        {
            if (last is not null)
            {
                last.Next = handler;
            }

            last = handler;
        }

        return _handlers.First();
    }
}