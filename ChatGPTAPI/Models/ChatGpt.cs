using System.ComponentModel.DataAnnotations;

namespace ChatGPTAPI.Models
{
    public class ChatGpt
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Summary { get; set; } = string.Empty;    
    }
     
}
