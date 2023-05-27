namespace eCommerceApp.Application.Models.Email
{
    public class EmailSettings
    {
        public string? ApiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY") ?? throw new ArgumentNullException("Key not found");
        public string FromAdress { get; set; } = string.Empty;
        public string FromName { get; set; } = string.Empty;
    }
}