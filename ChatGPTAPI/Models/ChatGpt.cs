using System.ComponentModel.DataAnnotations;

namespace ChatGPTAPI.Models
{
    public class ChatGpt
    {
        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Summary { get; set; }
    }
     
}
