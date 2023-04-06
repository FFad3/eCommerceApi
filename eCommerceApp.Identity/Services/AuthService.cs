using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using eCommerceApp.Application.Contracts.Identity;
using eCommerceApp.Application.Exceptions;
using eCommerceApp.Application.Features.Auth.Commands.Authentication;
using eCommerceApp.Application.Features.Auth.Commands.Refresh;
using eCommerceApp.Application.Features.Auth.Commands.Register;
using eCommerceApp.Application.Models.Identity;
using eCommerceApp.Application.Models.Settings;
using eCommerceApp.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace eCommerceApp.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthResponse?> Login(AuthCommand request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            _ = user ?? throw new NotFoundException($"User with {request.Email} not found.");

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded)
            {
                throw new BadRequestException($"Credentials for {request.Email} are invalid");
            }

            //Get user application claims
            var claims = await GetAuthClaims(user);

            //Generate Token & Refresh Token
            var token = GenerateToken(claims);
            var refreshToken = GenerateRefreshToken();
            //Set new refresh token
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_jwtSettings.RefreshTokenValidityInDays);
            //Update user with new refresh token
            await _userManager.UpdateAsync(user);

            var response = new AuthResponse
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = refreshToken,
                Expiration = token.ValidTo
            };

            return response;
        }

        public async Task<RegistrationResponse> Register(RegisterCommand request)
        {
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                StringBuilder sb = new();
                sb.AppendLine("Registration failed:");
                foreach (var error in result.Errors)
                {
                    sb.AppendFormat("-{0}\n", error.Description);
                }
                throw new BadRequestException($"{sb}");
            }

            await _userManager.AddToRoleAsync(user, UserRoles.User);
            return new RegistrationResponse() { UserId = user.Id };
        }

        public async Task<AuthResponse> RefreshToken(RefreshTokenCommand tokensPairModel)
        {
            var principal = GetPrincipalFromExpiredToken(tokensPairModel.AccessToken) ?? throw new SecurityTokenException("Invalid access token or refresh token");

            string userId = principal.FindFirstValue("uid") ?? throw new ArgumentNullException("Was null during RefreshToken method", nameof(userId));

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null
                || user.RefreshToken != tokensPairModel.RefreshToken
                || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                throw new SecurityTokenException("Invalid access token or refresh token");
            }

            var claims = principal.Claims;

            var newAccessToken = GenerateToken(claims);
            var newRefreshToken = GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            return new AuthResponse
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken,
                Expiration = DateTime.Now.AddDays(_jwtSettings.RefreshTokenValidityInDays),
            };
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private JwtSecurityToken GenerateToken(IEnumerable<Claim>? claims)
        {
            var symmetricSeciurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var signingCredentials = new SigningCredentials(symmetricSeciurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSeciurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: _jwtSettings.ExpirationDate,
                signingCredentials: signingCredentials);

            return jwtSeciurityToken;
        }

        private async Task<IEnumerable<Claim>> GetAuthClaims(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roleClaims = (await _userManager.GetRolesAsync(user))?.Select(r => new Claim(ClaimTypes.Role, r)).ToList() ?? new();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name,user.UserName ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email ?? ""),
                new Claim("uid",user.Id),
            }
            .Union(userClaims)
            .Union(roleClaims);

            return claims;
        }

        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        {
            var symmetricSeciurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            try
            {
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = symmetricSeciurityKey,
                    ValidateLifetime = false
                };

                var tokenHandler = new JwtSecurityTokenHandler();

                tokenHandler.CanReadToken(token);
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

                if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    throw new Exception();

                return principal;
            }
            catch (Exception ex)
            {
                throw new SecurityTokenException("Invalid token", ex);
            }
        }
    }
}