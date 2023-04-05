using System.ComponentModel.DataAnnotations;

namespace eCommerceApp.Application.Models.Identity
{
    public class AuthRequest
    {
        [Required(ErrorMessage ="Email is required")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;
    }

    public class AuthResponse
    {
        public string Token { get; init; } = string.Empty;
        public string RefreshToken { get; init; } = string.Empty;
        public DateTime Expiration { get; init; }
    }
}