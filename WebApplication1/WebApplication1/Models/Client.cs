using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class Client
    {
        [Key]
        public long ID { get; set; }
        public string? Name { get; set; }
        public string? Familia { get; set; }
        public DateOnly BDay { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }


    }

}
