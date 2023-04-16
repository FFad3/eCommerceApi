using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public string AccessToken { get; init; } = string.Empty;
        [JsonIgnore]
        public string RefreshToken { get; init; } = string.Empty;
        public string? Email { get; init; } = string.Empty;
        public string Role { get; init; } = string.Empty;
        public DateTime Expiration { get; init; }
    }
}