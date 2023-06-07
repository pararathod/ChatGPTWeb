using ChatGPTAPI.Models;
using ChatGPTAPI.Repository.Interface;

namespace ChatGPTAPI.Repository
{
    public class ChatGPTRepository : IChatGPTRepository
    {
        private readonly IChatGPTRepository _context;

        public ChatGPTRepository(IChatGPTRepository context)
        {
            _context = context;
        }

        public ChatGpt Add(ChatGpt chatrep)
        {
            throw new NotImplementedException();
        }
    }
}
