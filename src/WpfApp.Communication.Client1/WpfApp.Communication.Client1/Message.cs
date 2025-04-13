using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Communication.Client1
{
    internal class Message
    {
        public Message(string content, string? description = null)
        {
            Content = content;
            Description = description;
        }
        public string Content { get; set; }

        public string? Description { get; set; }

        public DateTime CreateTime { get; } = DateTime.Now;
    }
}
