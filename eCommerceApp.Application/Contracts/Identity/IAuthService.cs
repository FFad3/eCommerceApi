using eCommerceApp.Application.Models.Identity;

namespace eCommerceApp.Application.Contracts.Identity
{
    public interface IAuthService
    {
        /// <summary>
        /// Login user using credentials
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<AuthResponse> Login(AuthRequest request);
        /// <summary>
        /// Register user using provided data
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RegistrationResponse> Register(RegistrationRequest request);
        /// <summary>
        /// Refreshes token
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<AuthResponse> RefreshToken(TokensPairModel request);
    }
}