// Kaelin Hoang and Khanhly Nguyen

using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
/// <summary>
/// This class will set up how to do email verification for two factor. (Does not work yet)
/// </summary>
namespace WebApplication1.Models
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var task = new Task(() =>
            {
                SmtpClient smtpClient = new SmtpClient("smtp.utah.edu", 25);
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("admin@cs4540.com", "LOT");
                mail.To.Add(new MailAddress("germain@cs.utah.edu"));
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                smtpClient.Send(mail);
            });

            task.Start();
            return task;
        }
    }
}

