using eCommerceApp.Application.Contracts.Infrastructure;
using eCommerceApp.Application.Models.Email;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Text.Json;

namespace eCommerceApp.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings EmailSettings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
        {
            EmailSettings = emailSettings.Value;
            _logger = logger;
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

            message.SetClickTracking(false, false);

            var responseStatus = (await client.SendEmailAsync(message)).IsSuccessStatusCode;

            if (responseStatus)
            {
                _logger.LogInformation($"Email send: {JsonSerializer.Serialize(message)}");
            }

            return responseStatus;
        }
    }
}