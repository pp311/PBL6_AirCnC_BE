using Microsoft.Extensions.Hosting;

namespace AirCnC.Application.Commons.Helpers;

public enum TemplateType
{
    ResetPassword,
    ForgotPassword,
    BookingInfo,
}

public interface IMailTemplateHelper
{
    string GetBookingInfoTemplate(
        string guestName,
        DateTime bookingDate,
        string propertyName,
        DateTime checkInDate,
        DateTime checkOutDate,
        string address,
        string city,
        string hostName,
        string hostNumber,
        double total);
}

public class MailTemplateHelper : IMailTemplateHelper
{
    private readonly IHostEnvironment _env;

    public MailTemplateHelper(IHostEnvironment env)
    {
        _env = env;
    }
    public string GetBookingInfoTemplate(
            string guestName, 
            DateTime bookingDate, 
            string propertyName, 
            DateTime checkInDate,
            DateTime checkOutDate,
            string address,
            string city,
            string hostName,
            string hostNumber,
            double total)
    {
        var template = GetTemplate(TemplateType.BookingInfo)
            .Replace("{{name}}", guestName)
            .Replace("{{date}}", bookingDate.ToString("hh:mm dd/MM/yyyy"))
            .Replace("{{property_name}}", propertyName)
            .Replace("{{address}}", address)
            .Replace("{{city}}", city)
            .Replace("{{checkin_date}}", checkInDate.ToString("dd/MM/yyyy"))
            .Replace("{{checkout_date}}", checkOutDate.ToString("dd/MM/yyyy"))
            .Replace("{{host_name}}", hostName)
            .Replace("{{host_number}}", hostNumber)
            .Replace("{{total}}", total.ToString("C0"));

        return template;
    }

    public string GetTemplate(TemplateType templateName)
    {
        var pathToFile = GetTemplatePath(templateName.ToString());
        
        using var reader = File.OpenText(pathToFile);
        return reader.ReadToEnd();
    }

    private string GetTemplatePath(string templateName)
    {
        return $"{_env.ContentRootPath}{Path.DirectorySeparatorChar}wwwroot{Path.DirectorySeparatorChar}MailTemplates{Path.DirectorySeparatorChar}{templateName}.html";
    }
}
