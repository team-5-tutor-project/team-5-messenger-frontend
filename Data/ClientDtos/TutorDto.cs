namespace BlazorApp.Data.ClientDtos
{
    public class TutorDto
    {
        public TutorDto(string login, string name)
        {
            Login = login;
            Name = name;
        }
        
        public string Name { get; set; }
        
        public string Login { get; set; }
        
        public WorkFormat WorkFormat { get; set; }
        
        public string Description { get; set; }
        
        public int PricePerHour { get; set; }
        
        public int PupilMinClass { get; set; }
        
        public int PupilMaxClass { get; set; }
    }
}