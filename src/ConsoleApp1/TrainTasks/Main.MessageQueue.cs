using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.TrainTasks;

internal partial class Main
{
    public static void MessageQueueTest()
    {
        //MessageQueue queue = new MessageQueue("private" + "aaa");

        //new Thread(() =>
        //{
        //    queue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
        //    queue.Send("Hello, World!");
        //}).Start();

        //new Thread(() =>
        //{
        //    queue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
        //    string message = (string)queue.Receive().Body;
        //    Console.WriteLine(message);
        //}).Start();
    }
}
