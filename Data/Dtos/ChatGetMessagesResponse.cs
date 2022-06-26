using System.Collections.Generic;

namespace BlazorApp.Data
{
    public class ChatGetMessagesResponse
    {
        public List<Message> messages { get; set; }
        
        public IteratorDto next { get; set; }
    }
}