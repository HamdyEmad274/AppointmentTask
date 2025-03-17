using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentTask.Services
{
    public interface IUserService
    {
        Task<IdentityUser?> GetUserByEmailAsync(string email);
        Task<IEnumerable<IdentityUser>> GetAllUsersAsync();
        Task<bool> AssignRoleToUserAsync(string email, string role);
    }
}
