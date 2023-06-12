using ChatGPTAPI.Data;
using ChatGPTAPI.Models;
using ChatGPTAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static OpenAI.GPT3.ObjectModels.SharedModels.IOpenAiModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatGPTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IChatGPTRepository _service;

        public UserController(IChatGPTRepository service)
        {
            _service = service;
        }

        // GET: api/<UserController>
        [HttpGet]

        public async Task<ActionResult<IEnumerable<ChatGpt>>> GetAll()
        {
            var events = await _service.UserRepo.GetAllEvent();

            if (!events.Any())
            {
                return NotFound();
            }

            return Ok(events);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<ChatGpt>> Get(int id)
        {
            IEnumerable<ChatGpt> events = await _service.UserRepo.GetById(id);

            return events;
        }

        //POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Save(ChatGpt chtgpt)
        {
            try
            {
                await _service.UserRepo.Save(chtgpt);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.UserRepo.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



        // PUT api/<UserController>/5
        [HttpPut]
        public async Task<IActionResult> Put(ChatGpt gpt)
        {
            try
            {
                await _service.UserRepo.Put(gpt);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        //private bool CHTModelExists(int id)
        //{
        //    return (_service.MomSummary?.Any(e => e.Id == id)).GetValueOrDefault();
        //}


        // DELETE api/<UserController>/5
    }
}
