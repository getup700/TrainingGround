namespace WpfApp.Communication.Client1.Models
{
    internal class Message
    {
        public string Source { get; set; }

        public string Target { get; set; }

        public string Content { get; set; }

        public string? Description { get; set; }

        public DateTime CreateTime { get; } = DateTime.Now;

    }
}
