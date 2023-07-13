using ChatGPTAPI.Entities;

namespace ChatGPTAPI.Services
{
    public class ChatGPTService: IChatGPTService
    {
        private readonly IChatGPTService _context;

        public ChatGPTService(IChatGPTService context)
        {
            _context = context;
        }

        public ChatUser Add(ChatUser chatrep)
        {
            throw new NotImplementedException();
        }
    }
}



