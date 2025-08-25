using Patterns3.ChainsOfRepsonsibilty;
using Patterns3.ChainsOfRepsonsibilty.Handlers;

var card = new BankCard
{
    CvcCode = short.Parse(Console.ReadLine()!),
    Expires = TimeSpan.FromDays(365 * int.Parse(Console.ReadLine()!)),
    Number = Console.ReadLine()!,
    Owner = Console.ReadLine()!,
};
// 1234456789012345

var handlerBuilder = new HandlerBuilder<BankCard>();

handlerBuilder.AddHandler(new CheckCardNumberHandler());
handlerBuilder.AddHandler(new CheckCvcHandler());
handlerBuilder.AddHandler(new CheckExpiresHandler());

var mainHandler = handlerBuilder.Build();

mainHandler.Handle(new HandlerObject<BankCard>
{
    Data = card
});

internal class BankCard
{
    private TimeSpan _expires;
    private DateTime _issued;
    public required string Number { get; set; }

    public required TimeSpan Expires
    {
        get => _expires;
        set
        {
            _issued = DateTime.Now;

            _expires = value;
        }
    }

    public required string Owner { get; set; }
    public required short CvcCode { get; set; }

    public bool IsExpired()
    {
        return _issued.Add(_expires) < DateTime.Now;
    }
}

internal static class Helpers
{
    public static bool IsCardNumberValid(BankCard card)
    {
        for (int i = 0; i < card.Number.Length; i++)
        {
            if (!char.IsDigit(card.Number[i]))
            {
                return false;
            }
        }
        
        return true;
    }
}