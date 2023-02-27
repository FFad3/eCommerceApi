namespace eCommerceApp.Application.Models.Identity
{
    public class AuthRequest
    {
        public AuthRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}