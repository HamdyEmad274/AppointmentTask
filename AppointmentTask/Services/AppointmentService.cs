using AppointmentTask.Repositories;
using AppointmentTask.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentTask.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IdentityUser?> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task<IEnumerable<IdentityUser>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<bool> AssignRoleToUserAsync(string email, string role)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user != null)
            {
                return await _userRepository.AddUserToRoleAsync(user, role);
            }
            return false;
        }
    }
}
