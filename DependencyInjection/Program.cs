using DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

serviceCollection.AddSingleton<ILogger, ConsoleLogger>();
serviceCollection.AddTransient<ICounter, Counter>();

// ILogger logger = new ConsoleLogger();
// ICounter counter = new Counter(logger);

var serviceProvider = serviceCollection.BuildServiceProvider();

var counterService1 = serviceProvider.GetRequiredService<ICounter>();
var counterService2 = serviceProvider.GetRequiredService<ICounter>();
var counterService3 = serviceProvider.GetRequiredService<ICounter>();

counterService1.Increment();

Console.WriteLine(counterService1.Count);

counterService2.Increment();

Console.WriteLine(counterService2.Count);

counterService3.Increment();

Console.WriteLine(counterService3.Count);


