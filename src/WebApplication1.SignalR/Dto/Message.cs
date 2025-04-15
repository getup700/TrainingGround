namespace WpfApp.Communication.Client1.Models
{
    public class Message
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

        public Message(string sender, string receiver, string content)
        {
            Sender = sender;
            Receiver = receiver;
            Content = content;
            Timestamp = DateTime.UtcNow;
        }
    }
}