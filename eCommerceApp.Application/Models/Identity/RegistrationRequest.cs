using System.ComponentModel.DataAnnotations;

namespace eCommerceApp.Application.Models.Identity
{
    public class RegistrationRequest
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "UserName is required")]
        [MinLength(6)]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6)]
        public string Password { get; set; } = null!;
    }

    public class RegistrationResponse
    {
        public string Email { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string ToUrlParams => $"userid={UserId}&token={Token}";
    }
}