using PingPongManagmantSystem.Service.Interfaces.Common;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using PingPongManagmantSystem.DataAccess.Constans;
using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.Services.Common
{
    public class EmailService : IEmailService
    {
        AppDbContext appDbContext = new AppDbContext();
        public async Task<int> SendAsync()
        {
            try
            {
                string email = "";
                var resultUser = (User)await appDbContext.Users.FirstOrDefaultAsync(x => x.IsAdmin == 1);
                if (resultUser is not null)
                {
                    email = resultUser.Email;   
                    Random random = new Random();

                    var resultRandom = random.Next(1000, 9999);

                    var userEmail = new MimeMessage();

                    userEmail.From.Add(MailboxAddress.Parse("akbaraliyev555520@gmail.com"));
                    userEmail.To.Add(MailboxAddress.Parse(email));
                    userEmail.Subject = "Tasdiqlash kodi";
                    userEmail.Body = new TextPart(TextFormat.Html) { Text = $"{resultRandom}" };

                    var smtp = new SmtpClient();
                    await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    await smtp.AuthenticateAsync("akbaraliyev555520@gmail.com", "twofbjrqsbsnylfu");
                    await smtp.SendAsync(userEmail);
                    await smtp.DisconnectAsync(true);
                    return resultRandom;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}
