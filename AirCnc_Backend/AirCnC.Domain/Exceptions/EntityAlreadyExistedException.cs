namespace AirCnC.Domain.Exceptions;

public class EntityAlreadyExistedException : Exception
{
    public EntityAlreadyExistedException(string name, string key)
        : base($"'{name}' ({key}) was already existed.") { } 
}