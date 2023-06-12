using ChatGPTAPI.Entities;

namespace ChatGPTAPI.Services
{
    public interface IChatGPTService
    {
        ChatUser Add(ChatUser chatrep);
    }
}
