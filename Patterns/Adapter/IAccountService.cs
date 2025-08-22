namespace Patterns.Adapter;

internal interface IAccountService
{
    void Insert(Account account);
    void Remove(int id);
    Account? Get(int id);
}