using ChatGPTAPI.Models;
using ChatGPTAPI.Repository.Services;
using Microsoft.Extensions.Logging;

namespace ChatGPTAPI.Repository.Interface
{
    public interface IChatGPTRepository
    {
        Task<bool> SaveAsync();
        //void GetAllEvent();

        IUserService UserRepo { get; }
        
    }
}
