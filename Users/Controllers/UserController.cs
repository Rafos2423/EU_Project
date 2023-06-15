using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Users.Models;
using System.Threading.Tasks;
using Users.Controllers.Models;

namespace Users.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginIncomeModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Phone == model.Phone);

            if (user == null) return NotFound("Wrong phone number");
            if (user.Password != model.Password) return NotFound("Wrong password");

            return Ok();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            if (user.Phone == null) return Forbid("Phone is required");
            if (user.Password == null) return Forbid("Password is required");

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
