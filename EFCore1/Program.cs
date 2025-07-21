global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.SqlServer;
global using Microsoft.EntityFrameworkCore.Sqlite;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.Configuration.Json;
using ORMS;

var builder = new ConfigurationBuilder();

builder.AddJsonFile("config.json");

IConfiguration configuration = builder.Build();

// Code first
// Database first

var dbContext = new AppDbContext(configuration);

// dbContext.Database.EnsureDeleted();
dbContext.Database.EnsureCreated();


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
