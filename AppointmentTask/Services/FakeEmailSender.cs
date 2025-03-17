using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace AppointmentTask.Services
{
    public class FakeEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Simulate sending an email (do nothing)
            return Task.CompletedTask;
        }
    }
}
