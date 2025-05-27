using System.IO.Pipes;
using System.Reflection.Metadata;
using System.Text;

NamedPipeServerStream pipeServer;
const string pipeName = "MyMultiClientPipe";
// 增加最大并发连接数为5


// 设置最大并发连接数为5
pipeServer = new NamedPipeServerStream(pipeName,
    PipeDirection.Out,
    5,
    PipeTransmissionMode.Byte,
    PipeOptions.None);

pipeServer.WaitForConnection();
while (true)
{
    try
    {
        var message = "This is a message from server at " + DateTime.Now;
        var buffer = Encoding.UTF8.GetBytes(message);
        pipeServer.Write(buffer, 0, buffer.Length);
        pipeServer.Flush();
        //// 注意：这里没有Disconnect，因为要保持连接以服务多个客户端


    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        // 如果连接出错，可以选择尝试重新连接等操作
    }
    finally
    {
        Thread.Sleep(2000);
    }
}
