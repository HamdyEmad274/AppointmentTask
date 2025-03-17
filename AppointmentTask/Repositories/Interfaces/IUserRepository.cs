using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentTask.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityUser?> GetUserByEmailAsync(string email);
        Task<IEnumerable<IdentityUser>> GetAllUsersAsync();
        Task<bool> AddUserToRoleAsync(IdentityUser user, string role);
    }
}
