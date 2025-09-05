using CognifyAPI.Interfaces;
using System.Net.Mail;
using System.Net;

namespace CognifyAPI.Repositories
{
    public class SmtpMailRepository : IEmailRepository
    {
        private readonly IConfiguration _configuration;

        public SmtpMailRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmail(string toEmail, string subject, string body)
        {
            var message = new MailMessage(_configuration.GetValue<string>("SmtpSettings:Username")!, toEmail, subject, body);
            using var client = new SmtpClient(_configuration.GetValue<string>("SmtpSettings:Host")!, _configuration.GetValue<int>("SmtpSettings:Port")!)
            {
                Credentials = new NetworkCredential(_configuration.GetValue<string>("SmtpSettings:Username"), _configuration.GetValue<string>("SmtpSettings:Password")),
                EnableSsl = _configuration.GetValue<bool>("SmtpSettings:EnableSsl"),
                
            };

            await client.SendMailAsync(message);

        }
    }
}
