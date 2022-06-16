namespace BlazorApp.Data
{
    public class MessageDto
    {
        public MessageDto(string messageId, string text, string timeCreated)
        {
            message = new Message(messageId, text, timeCreated);
        }
        
        public Message message { get; set; }
    }
}