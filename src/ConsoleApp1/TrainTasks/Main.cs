using ConsoleApp1.Services;
using ConsoleApp1.TransientDepenSingleton;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.TrainTasks;

internal partial class Main
{
    public static void ServiceLifttime()
    {
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
    }



}
