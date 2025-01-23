using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/User
        [HttpGet]
        [Authorize(Roles = $"{Role.Admin},{Role.Modifier},{Role.Viewer}")]
        public async Task<ActionResult<IEnumerable<UserWithoutPassword>>> GetUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        [Authorize(Roles = $"{Role.Admin},{Role.Modifier},{Role.Viewer}")]
        public async Task<ActionResult<UserWithoutPassword>> GetUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        [Authorize(Roles = $"{Role.Admin}")]
        public async Task<ActionResult<UserWithoutPassword>> CreateUser(User user)
        {
            if (user == null)
            {
                return BadRequest("User data is null.");
            }

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                return BadRequest("Password is required.");
            }

            // Hash the password
            user.Password = HashHelper.ComputeMD5Hash(user.Password);

            var createdUser = await _userRepository.AddAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }

        // PUT: api/User/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = $"{Role.Admin}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest("User ID mismatch.");
            }

            var existingUser = await _userRepository.GetByIdAsyncComplete(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrWhiteSpace(user.Password))
            {
                // Hash the password only if it's provided
                user.Password = HashHelper.ComputeMD5Hash(user.Password);
            }
            else
            {
                // Keep the existing password if not provided
                user.Password = existingUser.Password;
            }

            await _userRepository.UpdateAsync(user);
            return NoContent();
        }

        // DELETE: api/User/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = $"{Role.Admin}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}