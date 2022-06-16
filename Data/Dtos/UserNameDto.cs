namespace BlazorApp.Data
{
    public class UserNameDto
    {
        public UserNameDto(string userName)
        {
            this.userName = userName;
        }
        
        public string userName { get; set; }
    }
}