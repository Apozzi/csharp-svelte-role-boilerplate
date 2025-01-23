using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        // GET: api/Role
        [HttpGet]
        [Authorize(Roles = $"{Role.Admin},{Role.Modifier},{Role.Viewer}")]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            var roles = await _roleRepository.GetAllAsync();
            return Ok(roles);
        }

        // GET: api/Role/{id}
        [HttpGet("{id}")]
        [Authorize(Roles = $"{Role.Admin},{Role.Modifier},{Role.Viewer}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        // POST: api/Role
        [HttpPost]
        [Authorize(Roles = $"{Role.Admin},{Role.Modifier}")]
        public async Task<ActionResult<Role>> CreateRole(Role role)
        {
            if (role == null)
            {
                return BadRequest("Role data is null.");
            }

            var createdRole = await _roleRepository.AddAsync(role);
            return CreatedAtAction(nameof(GetRole), new { id = createdRole.Id }, createdRole);
        }

        // PUT: api/Role/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = $"{Role.Admin},{Role.Modifier}")]
        public async Task<IActionResult> UpdateRole(int id, Role role)
        {
            if (id != role.Id)
            {
                return BadRequest("Role ID mismatch.");
            }

            var existingRole = await _roleRepository.GetByIdAsync(id);
            if (existingRole == null)
            {
                return NotFound();
            }

            await _roleRepository.UpdateAsync(role);
            return NoContent();
        }

        // DELETE: api/Role/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = $"{Role.Admin},{Role.Modifier}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            await _roleRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}