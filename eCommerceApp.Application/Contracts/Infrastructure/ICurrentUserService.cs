namespace eCommerceApp.Application.Contracts.Infrastructure
{
    public interface ICurrentUserService
    {
        public string UserName { get; }
        public Guid UserId { get; }
    }
}