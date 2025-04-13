using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Communication
{
    internal class Message
    {
        public Message(string content)
        {
            Content = content;
        }
        public string Content { get; set; }

        public DateTime CreateTime { get; } = DateTime.Now;
    }
}
