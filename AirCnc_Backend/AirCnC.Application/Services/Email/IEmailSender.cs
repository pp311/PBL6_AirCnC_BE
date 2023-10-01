namespace AirCnC.Application.Services.Email;

public interface IEmailSender
{
    Task SendEmailAsync(Message message);
}