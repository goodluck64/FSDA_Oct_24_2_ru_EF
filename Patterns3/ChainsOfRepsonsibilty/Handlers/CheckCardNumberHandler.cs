namespace Patterns3.ChainsOfRepsonsibilty.Handlers;

class CheckCardNumberHandler : HandlerBase<BankCard>
{
    public override void Handle(HandlerObject<BankCard> data)
    {
        Console.WriteLine("CheckCardNumberHandler::Handle");
        
        if (Helpers.IsCardNumberValid(data.Data))
        {
            Next?.Handle(data);
        }
    }
}