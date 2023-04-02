using eCommerceApp.Application.Contracts.Identity;
using eCommerceApp.Application.Exceptions;
using eCommerceApp.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace eCommerceApp.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<UserService> _logger;

        public UserService(UserManager<ApplicationUser> userManager, ILogger<UserService> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<User> GetUser(string userId)
        {
            var appUser = await _userManager.FindByIdAsync(userId)
                ?? throw new NotFoundException($"User with Id:{userId} not found");

            _logger.LogInformation("Get user by id:{id}", userId);

            return new User
            {
                Id = appUser.Id,
                Email = appUser.Email = null!,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
            };
        }

        public async Task<List<User>> GetUsers(params string[] roleNames)
        {
            var appUsers = new List<User>();

            foreach (var roleName in roleNames)
            {
                var usersInRole = await _userManager.GetUsersInRoleAsync(roleName);
                _logger.LogInformation("Role: {roleName} UsersCount: {count}",roleName,usersInRole.Count);

                if(usersInRole != null)
                {
                    var tmpUsers = usersInRole.Select(user => new User{
                        Id = user.Id,
                        Email = user.Email = null!,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                    }).ToList();

                    appUsers = appUsers.Union(tmpUsers).ToList();
                }
            }

            return appUsers;
        }
    }
}
