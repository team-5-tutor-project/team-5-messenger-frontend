namespace BlazorApp.Data.ClientDtos
{
    public class ClientDto
    {
        public ClientDto(string login, string name)
        {
            Login = login;
            Name = name;
        }
        
        public string Login { get; set; }
        
        public string Name { get; set; }
    }
}