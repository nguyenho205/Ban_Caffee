using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ban_Caffee.Models
{
    public class ChatMessage
    {
        public string? Sender { get; set; } // "User" hoặc "Bot"
        public string? Text { get; set; }
        public DateTime Timestamp { get; set; }
    }
}