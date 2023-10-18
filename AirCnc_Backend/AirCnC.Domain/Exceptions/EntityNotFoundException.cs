namespace AirCnC.Domain.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string name, string key)
        : base($"'{name}' ({key}) was not found.") {}
}