using eCommerceApp.Application.Contracts.Infrastructure;

namespace eCommerceApp.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.UtcNow;
    }
}