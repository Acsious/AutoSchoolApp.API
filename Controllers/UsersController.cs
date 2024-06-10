using AutoSchoolApp.API.Models;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("SearchUserById{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var users = await _context.Users.ToListAsync();

            if (users == null)
            {
                return NotFound();
            }

            var user = users.Find(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("LogInUser{login}/{password}")]
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
            return Ok(user);
        }

        [HttpPut("ChangePassword")]
        public async Task<ActionResult<User>> Update(int id, string password)
        {
            var users = await _context.Users.ToListAsync();
            var user = users.Find(x => x.Id == id);

            if (user == null)
                return BadRequest();

            if (!_context.Users.Any(x => x.Id == user.Id))
                return NotFound();

            user.Password = password;
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<User>> Create(string login, string password, string firstName, string secondName, string middleName, int roleId)
        {
            User user = new()
            {
                Login = login,
                Password = password,
                FirstName = firstName,
                MiddleName = middleName,
                SecondName = secondName,
                RoleId = roleId
            };

            if (Helper.IsExists(ref user, _context.Users.ToList()))
                return Ok(user);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete("RemoveUser{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
