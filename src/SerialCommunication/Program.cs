using System.IO.Ports;
using System.Text;


var ports = SerialPort.GetPortNames();
var port = new SerialPort()
{
    PortName = "COM4",//串口名称 
    BaudRate = 9600,//波特率
    Parity = Parity.None,//校验位
    DataBits = 8,//数据位
    StopBits = StopBits.One,//停止位
    Handshake = Handshake.None,
    ReadTimeout = 500,
    WriteTimeout = 500,
    ReadBufferSize = 4800,
    WriteBufferSize = 2048
};

port.ReceivedBytesThreshold = 1;
port.DataReceived += (s, e) =>
{
    switch (e.EventType)
    {
        case SerialData.Chars:
            Console.WriteLine(port.ReadExisting());
            break;
        case SerialData.Eof:
            break;
        default:
            break;
    }
};



//串口被打开后就被单独占用
port.Open();

while (true)
{
    await Task.Delay(100);
}
Console.WriteLine("dafsafds");

var word = "你好dddd";
var bytes = Encoding.UTF8.GetBytes(word);
port.Write(bytes,0,bytes.Length);

//var readWord = port.ReadExisting();
//var readBytes = new byte[10];
//port.Read(readBytes, 0, readBytes.Length);

//每次只读一个字节，一般写死循环读取
//var read3 = port.ReadByte();

//读取到指定字符为止
//var read4 = port.ReadTo(";");


port.Close();