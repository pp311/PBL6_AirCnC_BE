namespace AirCnC.Application.Services.Email;

public class Message
{
    public List<string> To { get; set; } = new();
    public string Subject { get; set; }
    public string Content { get; set; }
    public Message(IEnumerable<string> to, string subject, string content)
    {
        To.AddRange(to);
        Subject = subject;
        Content = content;        
    }}