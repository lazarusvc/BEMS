using Budget_Estimates_Management_System.Models;

using MimeKit;
using MailKit.Net.Smtp;

namespace Budget_Estimates_Management_System.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config) 
        { 
            _config = config;
        }
        public void SendEmail(EmailDTO request)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Budget Management", _config["EmailSettings:Email"]));
            message.To.Add(new MailboxAddress(request.To, request.To + _config["EmailSettings:Suffix"]));
            message.Subject = request.Subject;

            message.Body = new TextPart("plain")
            {
                Text = request.Message
            };

            using (var client = new SmtpClient())
            {
                client.Connect(_config["EmailSettings:Server"], 587, false);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate(_config["EmailSettings:User"], _config["EmailSettings:Pasword"]);

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
