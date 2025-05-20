using System.IO.Pipes;
using System.Text;

using NamedPipeServerStream pipeServer = new NamedPipeServerStream(
    "testpipe", PipeDirection.InOut, 1,
    PipeTransmissionMode.Message,
    PipeOptions.Asynchronous);


// 服务器端
while (true)
{
    if (pipeServer.IsConnected)
    {
        var message = Console.ReadLine();
        var buffer = Encoding.UTF8.GetBytes(message);

        await pipeServer.WriteAsync(buffer, 0, buffer.Length);
    }
    await Task.Delay(1000);
}


