using eCommerceApp.Application.Contracts.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace eCommerceApp.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContext)
        {
            _httpContextAccessor = httpContext;
        }

        public string UserName => this._httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "UKNOWN";

        public Guid UserId => throw new NotImplementedException();

        // TODO: Fix CurrentUserService Get UserId
        //public Guid UserId => Guid.Parse(this._httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);
    }
}