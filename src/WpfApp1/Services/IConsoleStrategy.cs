namespace WpfApp1.Services;

public interface IConsoleStrategy
{
    string Console();
}

public class HelloConsoleStrategy : IConsoleStrategy
{
    public string Console()
    {
        return "hello";
    }
}

public class HiConsoleStrategy : IConsoleStrategy
{
    public string Console()
    {
        return "hihihi";
    }
}
