using Applcation.Interface.Iservice;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;


namespace Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;


        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string TO, string Subject, string body)
        {

            try
            {
                var FromMail = _configuration["Stmp:From"];
                var port = int.Parse(_configuration["Stmp:Port"]);
                var stmpServer = _configuration["Stmp:SmtpServer"];
                var password = _configuration["Stmp:Password"];
                var username = _configuration["Stmp:Username"];

                var email = new MimeMessage();  
                email.From.Add(new MailboxAddress("Mail",FromMail));
                email.To.Add(new MailboxAddress("Recipient", TO));

                email.Subject = Subject;
                email.Body=new TextPart("html") { Text = body };

                using var smtp = new SmtpClient();
                
               await  smtp.ConnectAsync(stmpServer, port, SecureSocketOptions.StartTls);
               await smtp.AuthenticateAsync(username, password,cancellationToken: default);
                await smtp.SendAsync(email);

            }
            catch (Exception)
            {

                throw;
            }
         

        }
    }
}
