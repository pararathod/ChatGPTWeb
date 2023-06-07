using ChatGPTAPI.Models;

namespace ChatGPTAPI.Repository.Interface
{
    public interface IChatGPTRepository
    {
        ChatGpt Add(ChatGpt chatrep);
    }
}
