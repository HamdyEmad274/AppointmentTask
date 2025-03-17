using Microsoft.AspNetCore.Identity.UI.Services;

public class ConsoleEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        Console.WriteLine($"📧 Email to {email} | Subject: {subject}");
        return Task.CompletedTask;
    }
}
