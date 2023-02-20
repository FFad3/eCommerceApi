using eCommerceApp.Application.Models.Email;

namespace eCommerceApp.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(EmailMessage email);
    }
}