using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

var list = new List<string>() { "dsdfsdaf" };

var list2 = Update(list);

static IEnumerable<string> Update(IEnumerable<string> list)
{
    return list;
}

//var service = new MyService();
//service.Start();
//Thread.Sleep(3000);
//service.Stop();

//Thread.Sleep(1000);

class MyService
{
    volatile bool _isRunning;
    Thread _thread;

    public void Stop()
    {
        Console.WriteLine("Stop service");
        _isRunning = false;
    }

    public void Start()
    {
        Console.WriteLine("Start service");
        _thread = new Thread(() =>
        {
            _isRunning = true;
            ThreadJob();
        });
        _thread.IsBackground = true;
        _thread.Start();
    }

    void ThreadJob()
    {
        while (_isRunning)
        {
            Console.WriteLine("working...");
            Process();
        }
    }


    void Process()
    {
        Thread.Sleep(3000);

    }
}