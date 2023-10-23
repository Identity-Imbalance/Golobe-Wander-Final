using System.Net.Mail;
using System.Net;
using Globe_Wander_Final.Models.DTOs;

namespace Globe_Wander_Final.Models.Services
{
    public class EmailService 
    {
        private readonly IConfiguration _configuration;


        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public async Task sendEmail(EmailDTO email)
        {
          
            string email_APIkEY = "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";
            var toAddress = new MailAddress(_configuration["Brevo:AdminAddress"], _configuration["Brevo:DefaultFromName"]);
            var fromAddress = new MailAddress(email.Email, "osama");
            string fromPassword = _configuration["Brevo:fromPassword"];
            var AuthAddress = new MailAddress(_configuration["Brevo:AuthAddress"]);
            string Subject = "Recipet";
            string Body = $"  {email.Message}";


            var smtp = new SmtpClient
            {
                Host = "smtp-relay.brevo.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(AuthAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {

                Subject = Subject,
                Body = Body,
                IsBodyHtml = true

            })

            {
                message.Headers.Add("ApiKey", email_APIkEY);
                await smtp.SendMailAsync(message);

            }


            ;




        }
      

        }
    }

