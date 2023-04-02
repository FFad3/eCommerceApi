using eCommerceApp.Identity.Models;

namespace eCommerceApp.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<User>> GetUsers(params string[] roleNames);
        Task<User> GetUser(string userId);
    }
}
