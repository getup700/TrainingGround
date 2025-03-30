using ConsoleApp1.Services;
using ConsoleApp1.TransientDepenSingleton;
using Microsoft.Extensions.DependencyInjection;

var service = new ServiceCollection();

service.AddTransient<TransientService>();
service.AddSingleton<SingletonService>();
service.AddSingleton<ScopeService>();

service.AddTransient<Transient>();
service.AddSingleton<Singleton>();

var provider = service.BuildServiceProvider();

//Console.WriteLine(provider.GetService<SingletonService>().Console());
//Console.WriteLine(provider.GetService<SingletonService>().Console());
//Console.WriteLine(provider.GetService<SingletonService>().Console());
//Console.WriteLine(provider.GetService<SingletonService>().Console());

Console.WriteLine(provider.GetService<Transient>().Output());
Console.WriteLine(provider.GetService<Transient>().Output());
Console.WriteLine(provider.GetService<Singleton>().Output());
Console.WriteLine(provider.GetService<Singleton>().Output());
Console.WriteLine(provider.GetService<Singleton>().Output2());
Console.WriteLine(provider.GetService<Singleton>().Output2());