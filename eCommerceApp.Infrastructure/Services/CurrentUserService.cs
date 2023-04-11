using eCommerceApp.Application.Contracts.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace eCommerceApp.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContext)
        {
            _httpContextAccessor = httpContext;
        }

        public string UserName => this._httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(c=>c.Type== JwtRegisteredClaimNames.Name)?.Value ?? throw new SecurityTokenException("Incorrect Token");

        public Guid UserId => Guid.TryParse(this._httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value, out var userId) 
            ? userId : throw new SecurityTokenException("Incorrect Token");

    }
}