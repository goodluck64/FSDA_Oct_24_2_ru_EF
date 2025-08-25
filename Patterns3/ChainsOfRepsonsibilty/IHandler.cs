namespace Patterns3.ChainsOfRepsonsibilty;

interface IHandler<T>
{
    IHandler<T>? Next { get; set; }

    void Handle(HandlerObject<T> data);
    
    event Action<Exception> OnError;
}