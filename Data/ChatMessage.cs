namespace BlazorApp.Data
{
    public class ChatMessage
    {
        public ChatMessage(string username, string? body, bool mine)
        {
            Username = username;
            Body = body;
            Mine = mine;
        }

        public string Username { get; }
        public string? Body { get; }
        public bool Mine { get; private set; }

        public bool IsNotice => Body.StartsWith("(Notice)");

        public string CSS => Mine ? "sent" : "received";

        public void SetMine(bool mine)
        {
            Mine = mine;
        }
    }
}