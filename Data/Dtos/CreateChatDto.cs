namespace BlazorApp.Data
{
    public class CreateChatDto
    {
        public CreateChatDto(string chatName)
        {
            this.chatName = chatName;
        }

        public string chatName { get; set; }
    }
}