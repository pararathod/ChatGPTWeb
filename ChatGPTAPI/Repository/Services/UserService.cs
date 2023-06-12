using ChatGPTAPI.Data;
using ChatGPTAPI.Models;
using ChatGPTAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ChatGPTAPI.Repository.Services
{
    public class UserService : IUserService
    {
        private readonly ChatgptdbContext _dbcontext;

        public UserService(ChatgptdbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        /// <summary>
        /// Get All Users
        /// </summary>
        public async Task<IEnumerable<ChatGpt>> GetAllEvent()
        {
            return await _dbcontext.MomSummary.Select(x => new ChatGpt
            {
                Id = x.Id,
                Name = x.Name,
                Summary = x.Summary
            }).ToListAsync();
        }

        public async Task<IEnumerable<ChatGpt>> GetById(int id)
        {
            return await _dbcontext.MomSummary.Where(x=>x.Id==id).Select(x => new ChatGpt
            {
                Id = x.Id,
                Name = x.Name,
                Summary = x.Summary
            }).ToListAsync();
        }

        public async Task Delete(int id)
        {
            ChatGpt ct = _dbcontext.MomSummary.Find(id);           
                         _dbcontext.Remove(ct);
            await _dbcontext.SaveChangesAsync();

        }

        public async Task Save(ChatGpt chatGpt)
        {
            _dbcontext.MomSummary.Add(chatGpt);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task Put(ChatGpt gpt)
        {
            //if(!CHTModelExists(gpt.Id ))
            //{
            //    return 0;
            //}
            
            var a = _dbcontext.Entry(gpt).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return;
 
        }

        private bool CHTModelExists(int id)
        {
            return (_dbcontext.MomSummary?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
