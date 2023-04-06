using eCommerceApp.Application.Features.Auth.Commands.Authentication;
using eCommerceApp.Application.Features.Auth.Commands.Refresh;
using eCommerceApp.Application.Features.Auth.Commands.Register;
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
        Task<AuthResponse?> Login(AuthCommand request);
        /// <summary>
        /// Register user using provided data
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RegistrationResponse> Register(RegisterCommand request);
        /// <summary>
        /// Refreshes token
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<AuthResponse> RefreshToken(RefreshTokenCommand request);
    }
}