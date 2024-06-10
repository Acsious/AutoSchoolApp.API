using AutoSchoolApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AutoSchoolApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly DrivingDbContext _context;

        public UsersController(DrivingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{login}/{password}")]
        public async Task<ActionResult<User>> Get(string login, string password)
        {
            var users = await _context.Users.ToListAsync();

            if (users == null)
            {
                return NotFound();
            }

            var user = users.Find(x => x.Login == login && x.Password == password);

            if (user == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create(User user)
        {
            if (user == null)
            {  
                return BadRequest(); 
            }

            if (Helper.IsExists(ref user, _context.Users.ToList()))
            {
                return BadRequest();
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound(); 
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }
    }
}
