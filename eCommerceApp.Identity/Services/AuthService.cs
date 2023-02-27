using eCommerceApp.Application.Contracts.Identity;
using eCommerceApp.Application.Exceptions;
using eCommerceApp.Application.Models.Identity;
using eCommerceApp.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            _ = user ?? throw new NotFoundException($"User with {request.Email} not found.");

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded)
            {
                throw new BadRequestException($"Credentials for {request.Email} are invalid");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            var response = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email ?? "",
                UserName = user.UserName ?? "",
            };

            return response;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
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
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "test");
                return new RegistrationResponse() { UserId = user.Id };
            }
            else
            {
                StringBuilder sb = new();
                foreach (var error in result.Errors)
                {
                    sb.AppendFormat("!{0}\n", error.Description);
                }
                throw new BadRequestException($"{sb}");
            }
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            //Get Application and Roles claims
            var claims = await GetApplicationClaimsAsync(user);

            var symmetricSeciurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var signingCredentials = new SigningCredentials(symmetricSeciurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSeciurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSeciurityToken;
        }

        private async Task<IEnumerable<Claim>> GetApplicationClaimsAsync(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roleClaims = await GetApplicationRolesClaimsAsync(user);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub,user.Email ?? ""),
                new Claim("uid",user.Id),
            }
            .Union(userClaims)
            .Union(roleClaims);

            return claims;
        }

        private async Task<IEnumerable<Claim>> GetApplicationRolesClaimsAsync(ApplicationUser user)
        {
            //Returns claim(Role,RoleName)
            var roles = await _userManager.GetRolesAsync(user);
            var rolesClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

            return rolesClaims;
        }
    }
}