
namespace AirCnC.Application.Commons.Identity;

public interface ICurrentUser
{
    public string? Id { get; }
    public string? Name { get; }
    public string? Email { get; }
    public string? FullName { get; }
}