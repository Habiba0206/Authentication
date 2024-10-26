using System.Net.Mail;
using System.Net;
using Authentication.Application.Common.Settings;
using Authentication.Application.Common.Notifications.Servcies;
using Microsoft.Extensions.Options;

namespace Authentication.Infrastructure.Common.Notifications.Services;

public class EmailOrchestrationService : IEmailOrchestrationService
{
    private readonly EmailSenderSettings _emailSenderSettings;

    public EmailOrchestrationService(IOptions<EmailSenderSettings> emailSenderSettings)
    {
        _emailSenderSettings = emailSenderSettings.Value;
    }

    public ValueTask<bool> SendAsync(string emailAddress, string message)
    {
        var result = true;
        try
        {
            var mail = new MailMessage(_emailSenderSettings.CredentialAddress, emailAddress);
            mail.Subject = "Siz muvaffaqiyatli registratsiyadan o'tdingiz";
            mail.Body = message;

            var smtpClient = new SmtpClient(_emailSenderSettings.Host, _emailSenderSettings.Port); // Replace with your SMTP server address and port
            smtpClient.Credentials = new NetworkCredential(_emailSenderSettings.CredentialAddress, _emailSenderSettings.Password);
            smtpClient.EnableSsl = true;

            smtpClient.Send(mail);
        }
        catch (Exception ex)
        {
            result = false;
        }

        return new(result);
    }
}
