namespace BlazorApp.Data
{
    public class CreateChatWithTwoUsersDto
    {
        public CreateChatWithTwoUsersDto(string chatName, string userNameFirst, string userNameSecond)
        {
            this.chatName = chatName;
            this.userNameFirst = userNameFirst;
            this.userNameSecond = userNameSecond;
        }

        public string chatName { get; set; }
        
        public string userNameFirst { get; set; }
        
        public string userNameSecond { get; set; }
    }
}