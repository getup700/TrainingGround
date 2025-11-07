using ConsoleApp1.Serialize;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

public class Logger
{
    public static void Log(string message,
        [System.Runtime.CompilerServices.CallerFilePath] string filePath = "")
    {
        var watcher = new Stopwatch();
        watcher.Start();

        throw new Exception(message);
        //var type = Assembly.GetExecutingAssembly()
        //   .GetTypes()
        //   .FirstOrDefault(t => t.FullName.Contains(Path.GetFileNameWithoutExtension(filePath)));
        watcher.Stop();
        Console.WriteLine($"[{filePath}] {message}\n{watcher.ElapsedMilliseconds}");
    }

    public static void Log2(string message)
    {
        throw new Exception(message);
        var watcher = new Stopwatch();
        watcher.Start();
        var stackTrace = new StackTrace(true);
        var callingFrame = stackTrace.GetFrame(1);
        var callingClass = callingFrame.GetMethod().DeclaringType;
        watcher.Stop();
        Console.WriteLine($"[{callingClass?.Name}] {message}\n{watcher.ElapsedMilliseconds}");
    }
}

public class SampleClass1
{
    public void DoSomething()
    {
        Logger.Log2("Log2 This is a log message from SampleClass1");
        Logger.Log("Log This is a log message from SampleClass1");
    }
}

public class SampleClass2
{
    public void DoAnotherThing()
    {
        Logger.Log2("Log2 This is a log message from SampleClass2");
        Logger.Log("Log This is a log message from SampleClass2");
    }
}

class Program
{
    static void Main()
    {
        //   var sample1 = new SampleClass1();
        //   sample1.DoSomething();

        //   var sample2 = new SampleClass2();
        //   sample2.DoAnotherThing();

        //new SampleClass1().DoSomething();


        //Action action1 = Run1;
        //action1 += Run2;
        //action1 += Run3;
        //action1 += Run2;

        //action1.Invoke();

        SerializeTest.Run();
       
    }

    public static void Run1()
    {
        Console.WriteLine("111111111");
    }
    public static void Run2()
    {
        Console.WriteLine("222222222");
    }
    public static void Run3()
    {
        Console.WriteLine("333333333");
    }
}