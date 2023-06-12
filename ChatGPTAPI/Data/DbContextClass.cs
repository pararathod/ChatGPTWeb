using ChatGPTAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatGPTAPI.Data
{
    public class DbContextClass: DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<FileDetails> FileDetails { get; set; }
        public virtual DbSet<ChatUser> MomSummary { get; set; }
    }
}
