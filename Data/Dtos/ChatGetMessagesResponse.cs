using System.Collections.Generic;

namespace BlazorApp.Data
{
    public class ChatGetMessagesResponse
    {
        public ChatGetMessagesResponse(List<Message> messages, string next)
        {
            this.messages = new List<Message>(messages);
            this.next = next;
        }
        
        public List<Message> messages { get; set; }
        
        public string next { get; set; }
    }
}