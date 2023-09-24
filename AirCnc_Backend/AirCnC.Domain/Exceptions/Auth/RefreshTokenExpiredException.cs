namespace AirCnC.Domain.Exceptions.Auth;

public class RefreshTokenExpiredException : Exception
{
    public RefreshTokenExpiredException(string refreshToken)
        : base($"RefreshToken ({refreshToken}) was expired") { } 
}