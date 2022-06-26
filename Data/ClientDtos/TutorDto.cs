namespace BlazorApp.Data.ClientDtos
{
    public class TutorDto
    {
        public TutorDto(string login, string name)
        {
            this.login = login;
            this.name = name;
        }
        
        public string name { get; set; }
        
        public string login { get; set; }
        
        public WorkFormat norkFormat { get; set; }
        
        public string description { get; set; }
        
        public int pricePerHour { get; set; }
        
        public int pupilMinClass { get; set; }
        
        public int pupilMaxClass { get; set; }
    }
}