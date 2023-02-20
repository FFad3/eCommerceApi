using eCommerceApp.Application.Contracts.Infrastructure;
using eCommerceApp.Application.Models.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Text.Json;

namespace eCommerceApp.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public readonly EmailSettings EmailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            EmailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmail(EmailMessage email)
        {
            var client = new SendGridClient(EmailSettings.ApiKey);
            var to = new EmailAddress
            {
                Email = email.To,
                Name = "Customer"
            };
            var from = new EmailAddress
            {
                Email = EmailSettings.FromAdress,
                Name = EmailSettings.FromName,
            };

            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            Console.WriteLine(JsonSerializer.Serialize(message));
            var response = await client.SendEmailAsync(message);
            return response.IsSuccessStatusCode;
        }
    }
}