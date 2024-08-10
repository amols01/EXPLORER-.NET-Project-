using Bhatkanti.Models;
using System.Data;

namespace Bhatkanti.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<M_Roles>> GetAllRolesAsync();
        Task<M_Roles> GetRoleByIdAsync(int id);
        Task<M_Roles> CreateRoleAsync(M_Roles role);
        Task<M_Roles> UpdateRoleAsync(M_Roles role);
        Task DeleteRoleAsync(int id);
    }
}
