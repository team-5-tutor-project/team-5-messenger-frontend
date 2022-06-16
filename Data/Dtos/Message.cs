namespace BlazorApp.Data
{
    public class Message
    {
        public Message(string messageId, string text, string timeCreated)
        {
            this.messageId = messageId;
            this.text = text;
            this.timeCreated = timeCreated;
        }

        public string messageId { get; set; }
        
        public string text { get; set; }
        
        public string timeCreated { get; set; }
    }
}