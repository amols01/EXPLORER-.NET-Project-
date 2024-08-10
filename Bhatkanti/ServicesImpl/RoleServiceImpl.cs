using Bhatkanti.Models;
using Bhatkanti.Services;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Bhatkanti.ServicesImpl
{
    public class RoleServiceImpl : IRoleService
    {
        private readonly ApplicationDbContext _context;

        public RoleServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<M_Roles>> GetAllRolesAsync()
        {
            return await _context.M_Roles.ToListAsync();
        }

        public async Task<M_Roles> GetRoleByIdAsync(int id)
        {
            return await _context.M_Roles.FindAsync(id);
        }

        public async Task<M_Roles> CreateRoleAsync(M_Roles role)
        {
            _context.M_Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<M_Roles> UpdateRoleAsync(M_Roles role)
        {
            _context.M_Roles.Update(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task DeleteRoleAsync(int id)
        {
            var role = await _context.M_Roles.FindAsync(id);
            if (role != null)
            {
                _context.M_Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
        }
    }
}
