using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingsController : ControllerBase
    {
        private readonly GreetingContext _context;

        public GreetingsController(GreetingContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Greeting>> CreateGreeting(Greeting greeting)
        {
            var greetingToAdd = new Greeting(){Content = greeting.Content};
            await _context.Greetings.AddAsync(greetingToAdd);
            await _context.SaveChangesAsync();
            return greetingToAdd;
        }
    }
}