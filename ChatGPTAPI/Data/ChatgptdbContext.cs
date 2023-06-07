using ChatGPTAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace ChatGPTAPI.Data
{
    public class ChatgptdbContext : DbContext
    {
        public ChatgptdbContext(DbContextOptions<ChatgptdbContext> options) : base(options)
        { }
        public virtual DbSet<ChatGpt> Users { get; set; }
    }
}
