using Microsoft.AspNetCore.Identity;

namespace eCommerceApp.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } =string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
