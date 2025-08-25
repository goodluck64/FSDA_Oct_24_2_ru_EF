namespace Patterns3.ChainsOfRepsonsibilty.Handlers;

class CheckExpiresHandler : HandlerBase<BankCard>
{
    public override void Handle(HandlerObject<BankCard> data)
    {
        Console.WriteLine("CheckExpiresHandler::Handle");

        if (!data.Data.IsExpired())
        {
            Next?.Handle(data);

            Console.WriteLine("Job done!");
        }
        else
        {
            FireOnError(new Exception("Card is expired."));
        }
    }
}