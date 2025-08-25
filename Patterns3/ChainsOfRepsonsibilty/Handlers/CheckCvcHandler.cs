namespace Patterns3.ChainsOfRepsonsibilty.Handlers;

class CheckCvcHandler : HandlerBase<BankCard>
{
    public override void Handle(HandlerObject<BankCard> data)
    {
        Console.WriteLine("CheckCvcHandler::Handle");
        
        if (data.Data.CvcCode is >= 100 and <= 999)
        {
            Next?.Handle(data);
        }
    }
}