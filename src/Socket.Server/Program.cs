using System.Net.Sockets;



var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Bind(new System.Net.IPEndPoint(System.Net.IPAddress.Any, 5000));
socket.Listen(10);
Console.WriteLine("Server is listening on port 5000...");
while (true)
{
    var clientSocket = socket.Accept();
    Console.WriteLine("Client connected.");
    
    // Handle client connection in a separate thread or task
    _ = Task.Run(() => HandleClient(clientSocket));
}

void HandleClient(Socket clientSocket)
{
    try
    {
        var buffer = new byte[1024];
        int bytesRead;
        while ((bytesRead = clientSocket.Receive(buffer)) > 0)
        {
            Console.WriteLine($"Received {bytesRead} bytes from client.");
            // Echo back the received data
            clientSocket.Send(buffer, bytesRead, SocketFlags.None);
        }
    }
    catch (SocketException ex)
    {
        Console.WriteLine($"Socket error: {ex.Message}");
    }
    finally
    {
        clientSocket.Close();
        Console.WriteLine("Client disconnected.");
    }
}
