using ChatGPTAPI.Data;
using ChatGPTAPI.Models;
using ChatGPTAPI.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ChatGPTAPI.Repository.Services
{
    public class ChatGPTRepository : IChatGPTRepository
    {
       
        public ChatGPTRepository(ChatgptdbContext context)
        {
            _context = context;
        }

        public ChatgptdbContext _context;
        public IUserService UserRepo => new UserService(_context);

        public IUserService EventRepo => throw new NotImplementedException();

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
