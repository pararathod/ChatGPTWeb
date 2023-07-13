using System.ComponentModel.DataAnnotations;

namespace ChatGPTAPI.Entities
{
    public class ChatUser
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Summary { get; set; } = string.Empty;
    }
}
