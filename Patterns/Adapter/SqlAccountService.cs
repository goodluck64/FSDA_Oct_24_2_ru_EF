namespace Patterns.Adapter;

internal class SqlAccountService : IAccountService
{
    public void Insert(Account account)
    {
        Console.WriteLine("[SqlAccountService::Insert]");
    }

    public void Remove(int id)
    {
        Console.WriteLine("[SqlAccountService::Remove]");
    }

    public Account? Get(int id)
    {
        Console.WriteLine("[SqlAccountService::Get]");

        return null;
    }
}