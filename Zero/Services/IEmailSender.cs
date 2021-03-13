using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace Zero.Services
{
    //public interface IEmailSender
    //{

    //}

    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
