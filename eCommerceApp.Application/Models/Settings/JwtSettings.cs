namespace eCommerceApp.Application.Models.Settings
{
    public class JwtSettings
    {
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public double DurationInMinutes { get; set; }
        public double RefreshTokenValidityInDays { get; set; }
        public DateTime ExpirationDate => DateTime.Now.AddMinutes(DurationInMinutes);
    }

    public static class JwtTokensNames
    {
        public static string AccessToken = "access_token";
        public static string RefreshToken = "refresh_token";
    }
}