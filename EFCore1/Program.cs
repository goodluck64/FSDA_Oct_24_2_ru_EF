global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.SqlServer;
global using Microsoft.EntityFrameworkCore.Sqlite;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.Configuration.Json;
using EFCore1;
using EFCore1.Entities;

var builder = new ConfigurationBuilder();

builder.AddJsonFile("config.json");

IConfiguration configuration = builder.Build();

// Code first
// Database first

var dbContext = new AppDbContext(configuration);

// dbContext.ChangeTracker.AutoDetectChangesEnabled = false;

// dbContext.Database.EnsureDeleted();
dbContext.Database.EnsureCreated();


//// SELECT
// var publisherName = "Nintendo";
// var games = dbContext.Games
//     .Include(g => g.Publisher)
//     .Where(g => g.Publisher.Name == publisherName);
//
// foreach (var game in games)
// {
//     Console.WriteLine($"{game.Name}: {game.Price} | {game.Publisher.Name}");
// }

//// INSERT

// var publisher = new Publisher
// {
//     Name = "Govno"
// };
//
// dbContext.Publishers.Add(publisher);
// dbContext.Publishers.Add(new Publisher
// {
//     Name = "Mocha"
// });
//
// dbContext.SaveChanges();

//// DELETE

// // 1
// dbContext.Publishers.Remove(new Publisher
// {
//     Id = 1
// });
// dbContext.SaveChanges();

// // 2
// dbContext.Database.BeginTransaction();
// dbContext.Publishers.Where(g => g.Id == -2 || g.Id == 1).ExecuteDelete();
// dbContext.Database.CommitTransaction();


//// UPDATE

// dbContext.Publishers.Update(new Publisher
// {
//     Id = 2,
//     Name = "Mocha Arts"
// });

// var game = dbContext.Games.First(x => x.Id == -1);
//
// game.Price *= 0.9m;
//
// dbContext.SaveChanges();

// foreach (var g in dbContext.Games.Local)
// {
//     Console.WriteLine(g.Id);
// }

// dbContext.SaveChanges();


//////////////////////////////////////////
//// Eager loading
// var result = dbContext.Games
//     .Include(g => g.Publisher)
//     .ThenInclude(p => p.Games)
//     .Include(g => g.Categories)
//     .Single(x => x.Id == -9);
//
// Console.WriteLine(result.Publisher.Name);
// Console.WriteLine(result.Publisher.Games.Count);
// Console.WriteLine(result.Categories.Count);

//// Lazy loading

// var result = dbContext.Games.Single(g => g.Id == -10);  // <- 1s
//
// Console.WriteLine(result.Name);
// Console.WriteLine(result.Publisher.Name);

//// Explicit loading

var game = dbContext.Find<Game>(-10);

if (game is null)
{
    return;
}

var gameEntry = dbContext.Entry(game);

gameEntry.Reference(g => g.Publisher).Load();
gameEntry.Collection(g => g.Categories).Load();

gameEntry.Reload();

Console.WriteLine(game.Publisher.Name);
Console.WriteLine(game.Categories.Count);


//////////////////////////////////////////
// SOLID
// S - Single Responsibility

//// Violation
// class UserManager
// {
//     public void AddUser(object user)
//     {
//         
//     }
//     
//     public void AddItem(object item)
//     {
//         
//     }
// }

//// Ok
// class UserManager
// {
//     public void AddUser(object user)
//     {
//         
//     }
//     
//     public void RemoveUser(object user)
//     {
//         
//     }
// }

// O - Open/Closed

//// Violation
// class Collection
// {
//     public int Length; // <-----
//
//     public void Add(int value)
//     {
//         Length++;
//     }
//
//     public void Remove(int value)
//     {
//         Length--;
//     }
// }

//// Ok
// class Collection
// {
//     private int _length;
//
//     public virtual void Add(int value)
//     {
//         _length++;
//     }
//
//     public virtual void Remove(int value)
//     {
//         _length--;
//     }
// }

// L - Liskov Substitution
interface IAction
{
    void Execute(object data);
}

class DefaultAction : IAction
{
    public void Execute(object data)
    {
        Console.WriteLine("DefaultAction");
    }
}

class CompositeAction : IAction
{
    public void Execute(object data)
    {
        Console.WriteLine("CompositeAction");
    }

    public void AddCompositeAction(CompositeAction action)
    {
        // ...
    }
}


// Ok
// CompositeAction action = new CompositeAction();
//
// action.AddCompositeAction(new CompositeAction());
//
// ExecuteAction(action);
//
// void ExecuteAction(IAction action)
// {
//     action.Execute(new object());
// }

// Violation

// CompositeAction action = new CompositeAction();
//
// ExecuteAction(action);
//
// void ExecuteAction(CompositeAction action) // -> void ExecuteAction(IAction action)
// {
//     action.Execute(new object());
//     action.AddCompositeAction(new CompositeAction());
// }


// I - Interface Segregation

// Violation
// interface IEntityService
// {
//     void AddEntity(object entity);
//     void RemoveEntity(object entity);
//     bool ValidateEntity(object entity);
//     bool SaveEntity(object entity);
//     bool LoadEntity(object entity);
// }

// Ok
interface IEntityManager
{
    void AddEntity(object entity);
    void RemoveEntity(object entity);
}

interface IEntityValidator
{
    bool ValidateEntity(object entity);
}

interface IEntityIo
{
    bool SaveEntity(object entity);
    bool LoadEntity(object entity);
}


// D - Dependency Inversion

// Violation
// interface IDbService
// {
//     void Add(object data);
//     void Remove(object data);
//     List<object> GetAll();
// }

// Ok


class DbData;

interface IDbService
{
    void Add(DbData data);
    void Remove(DbData data);
    DbData GetById(int id);
    ICollection<DbData> GetAll();
}

interface IPrintable
{
    void Print();
}