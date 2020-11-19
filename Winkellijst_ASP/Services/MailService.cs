using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SendGrid;
using SendGrid.Helpers;
using SendGrid.Helpers.Mail;

namespace Winkellijst_ASP.Services
{
    public class MailService : IMailService
    {
        private readonly string _sendGridApiKey = "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";

        public Task SendPasswordResetLink(string email, string name, string url)
        {
            if (!string.IsNullOrWhiteSpace(_sendGridApiKey))
            {
                var client = new SendGridClient(_sendGridApiKey);
                var from = new EmailAddress("noreply@localhost", "Winkellijst");
                var to = new EmailAddress(email, name);
                var plainTextContent = url;
                var htmlContent = "<a href=\"" + url + "\">Reset password</a>";
                var subject = plainTextContent;
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

                try
                {
                    client.SendEmailAsync(msg).Wait();
                    return Task.FromResult(0);
                }
                catch (Exception) { }
            }

            return Task.FromResult(1);
        }
    }
}
