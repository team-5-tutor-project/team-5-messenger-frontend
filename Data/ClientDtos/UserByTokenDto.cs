namespace BlazorApp.Data.ClientDtos
{
    public class UserByTokenDto
    {
        public UserByTokenDto(string userId, string userType)
        {
            this.userId = userId;
            this.userType = userType;
        }
        
        public string userId { get; set; }
        
        public string userType { get; set; }
    }
}