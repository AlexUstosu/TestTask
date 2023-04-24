namespace WebApplication1.Models
{
    public class Client
    {
        public int _id;
        public string? Name { get; set; }
        public string? Familia { get; set; }
        public DateOnly BDay { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}
