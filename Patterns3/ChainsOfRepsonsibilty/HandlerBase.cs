namespace Patterns3.ChainsOfRepsonsibilty;

abstract class HandlerBase<T> : IHandler<T>
{
    private IHandler<T>? _next;

    public IHandler<T>? Next
    {
        get => _next;
        set
        {
            if (value is not null)
            {
                _next = value;

                _next.OnError += OnError;
            }
        }
    }

    public abstract void Handle(HandlerObject<T> data);
    public event Action<Exception>? OnError;

    protected void FireOnError(Exception ex)
    {
        OnError?.Invoke(ex);
    }
}