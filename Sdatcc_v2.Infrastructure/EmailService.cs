/*using Sdatcc_v2.Domain;
using System.Net.Mail;
using System.Threading.Tasks;

public class EmailService : IEmailService
{
    private readonly SmtpClient _smtpClient;

    public EmailService(SmtpClient smtpClient)
    {
        _smtpClient = smtpClient;
    }

    public async Task SendEmailAsync(string senderAddress, string recipientAddress, string subject, string body)
    {
        var message = new MailMessage(senderAddress, recipientAddress, subject, body);
        await _smtpClient.SendMailAsync(message);
    }
}
*/