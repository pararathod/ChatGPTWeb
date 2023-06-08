using ChatGPTAPI.Data;
using ChatGPTAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static OpenAI.GPT3.ObjectModels.SharedModels.IOpenAiModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatGPTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ChatgptdbContext _context;

        public UserController(ChatgptdbContext context)
        {
            _context = context;
        }

        // GET: api/<UserController>
        [HttpGet]

        public async Task<ActionResult<IEnumerable<ChatGpt>>> Get()      
        {
            if (_context.MomSummary == null)
            {
                return NotFound();
            }
            return await _context.MomSummary.ToListAsync();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatGpt>> Get(int id)
        {
            if (_context.MomSummary == null)
            {
                return NotFound();
            }
            var usrModel = await _context.MomSummary.FindAsync(id);

            if (usrModel == null)
            {
                return NotFound();
            }

            return usrModel;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<ChatGpt>> Post(ChatGpt chtgpt)       
        {
            if (_context.MomSummary == null)
            {
                return Problem("Entity set 'UserContext.UserModel'  is null.");
            }
            _context.MomSummary.Add(chtgpt);
            await _context.SaveChangesAsync();

            return Ok();

        }

        // PUT api/<UserController>/5
        [HttpPut]
        public async Task<IActionResult> Put(ChatGpt gpt)       
        {
            if (gpt == null)
            {
                return BadRequest();
            }
            _context.Entry(gpt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CHTModelExists(gpt.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool CHTModelExists(int id)
        {
            return (_context.MomSummary?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)        
        {
            if (_context.MomSummary == null)
            {
                return NotFound();
            }
            var bookModel = await _context.MomSummary.FindAsync(id);
            if (bookModel == null)
            {
                return NotFound();
            }

            _context.MomSummary.Remove(bookModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
