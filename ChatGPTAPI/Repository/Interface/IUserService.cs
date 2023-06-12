using ChatGPTAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static OpenAI.GPT3.ObjectModels.SharedModels.IOpenAiModels;

namespace ChatGPTAPI.Repository.Interface
{
    public interface IUserService
    {



        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns type="Task<IEnumerable<UserViewModel>>"></returns>
        Task<IEnumerable<ChatGpt>> GetAllEvent();

        /// <summary>
        /// Get Users by Id 
        /// </summary>
        /// <returns type="IEnumerable<TblUser>"></return
        /// 

        Task<IEnumerable<ChatGpt>> GetById(int id);

        /// <summary>
        /// Save Data 
        /// </summary>
        /// <returns type="IEnumerable<TblUser>"></return
        /// 

        Task Save(ChatGpt chatgpt);

        Task Delete(int id);

        Task Put(ChatGpt gpt);

    }
}
