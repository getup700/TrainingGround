using System.IO.Pipes;
using System.Reflection.Metadata;
using System.Security.Principal;
using System.Text;

const string pipeName = "MyMultiClientPipe";
NamedPipeClientStream pipeClient;


pipeClient = new NamedPipeClientStream(".",
    pipeName,
    PipeDirection.In,
    PipeOptions.None);

await pipeClient.ConnectAsync();

while (true)
{
    try
    {
        byte[] buffer = new byte[1024];
        int bytesRead = pipeClient.Read(buffer, 0, buffer.Length);
        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        Console.WriteLine($"Received: {message}");

        //var reader = new StreamReader(pipeClient, Encoding.UTF8);
        //var message = await reader.ReadLineAsync();
        //Console.WriteLine(message);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        // 如果连接出错，可以选择重试连接等操作
    }
}

