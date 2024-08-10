using Bhatkanti.Models;
using Bhatkanti.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bhatkanti.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<M_Roles>>> GetRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();
            if (roles == null || !roles.Any())
            {
                return NotFound(new { Message = "No roles found." });
            }
            return Ok(new { Roles = roles, Message = "Roles retrieved successfully." });
        }

        // GET: api/roles/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<M_Roles>> GetRole(int id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound(new { Message = "Role not found." });
            }
            return Ok(new { Role = role, Message = "Role retrieved successfully." });
        }
    }
}
