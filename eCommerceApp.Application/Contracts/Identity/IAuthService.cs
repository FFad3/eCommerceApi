using eCommerceApp.Application.Models.Identity;

namespace eCommerceApp.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);

        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}