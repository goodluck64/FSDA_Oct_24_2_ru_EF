using System.Text.Json;

namespace Patterns.Adapter;

internal sealed class MongoDbAdapterService : IAccountService
{
    private readonly MongoDbService _mongoDbService;

    public MongoDbAdapterService(MongoDbService mongoDbService)
    {
        _mongoDbService = mongoDbService;
    }
    
    public void Insert(Account account)
    {
        _mongoDbService.Insert(account.Id, account.Login, account.PasswordHash);
    }

    public void Remove(int id)
    {
        _mongoDbService.Delete(id);
    }

    public Account? Get(int id)
    {
        var document = _mongoDbService.Fetch(id);

        return document.Deserialize<Account>();
    }
}