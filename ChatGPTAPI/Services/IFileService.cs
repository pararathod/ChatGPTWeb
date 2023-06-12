using ChatGPTAPI.Entities;

namespace ChatGPTAPI.Services
{
    public interface IFileService
    {
        public Task PostFileAsync(IFormFile fileData, FileType fileType);
      
    }
}
