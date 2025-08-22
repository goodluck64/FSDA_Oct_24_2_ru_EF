// var obj = World.Instance;
//
// obj.StartGame();
//
// var obj2 = World.Instance;
//
// obj2.InitGame();
//
// internal sealed class World
// {
//     private readonly Guid _guid = Guid.NewGuid();
//
//     private World()
//     {
//     }
//
//     public void StartGame()
//     {
//         Console.WriteLine($"[World::StartGame]: {_guid}");
//     }
//
//     public void InitGame()
//     {
//         Console.WriteLine($"[World::InitGame]: {_guid}");
//     }
//
//     private static World? _instance;
//     public static World Instance => _instance ??= new World();
// }