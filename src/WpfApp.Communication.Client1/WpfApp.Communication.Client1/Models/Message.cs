namespace WpfApp.Communication.Client1.Models
{
    internal class Message
    {
        public string Sender { get; set; }

        public string Receiver { get; set; }

        public string Content { get; set; }

        public string? Description { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;

    }
}
