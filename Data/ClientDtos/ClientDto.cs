namespace BlazorApp.Data.ClientDtos
{
    public class ClientDto
    {
        public ClientDto(string login, string name)
        {
            this.login = login;
            this.name = name;
        }
        
        public string login { get; set; }
        
        public string name { get; set; }
    }
}