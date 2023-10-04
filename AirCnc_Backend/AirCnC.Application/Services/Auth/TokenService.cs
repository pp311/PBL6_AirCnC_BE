using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AirCnC.Application.Commons;
using AirCnC.Application.Services.Auth.Specifications;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Exceptions;
using AirCnC.Domain.Exceptions.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AirCnC.Application.Services.Auth;

public interface ITokenService
{
    string GenerateRefreshToken();
    Task<string> GenerateAccessTokenAsync(int userId);
    Task AddRefreshTokenAsync(int userId, string refreshToken);
    Task<RefreshToken> ValidateRefreshTokenAsync(string refreshToken);
    Task RevokeRefreshTokenAsync(string refreshToken);
}

public class TokenService : ITokenService
{
    private readonly UserManager<User> _userManager;
    private readonly IRepository<RefreshToken> _tokenRepository;
    private readonly JwtSettings _jwtSettings;
    private readonly IUnitOfWork _unitOfWork;

    public TokenService(UserManager<User> userManager, 
                        IOptions<JwtSettings> jwtSettings,
                        IRepository<RefreshToken> tokenRepository,
                        IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _tokenRepository = tokenRepository;
        _unitOfWork = unitOfWork;
        _jwtSettings = jwtSettings.Value;
    }

    public string GenerateRefreshToken()
    {
        return Guid.NewGuid().ToString();
    }

    public async Task<string> GenerateAccessTokenAsync(int userId)
    {
        // 1. Create header and signature 
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey));
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        // 2. Create Jwt
        var tokenOptions = new JwtSecurityToken(
            issuer: _jwtSettings.ValidIssuer,
            audience: _jwtSettings.ValidAudience,
            claims: await GetUserClaimListAsync(userId),
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpiryInMinutes),
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    public async Task AddRefreshTokenAsync(int userId, string refreshToken)
    {
        var refreshTokenLifetime = DateTime.UtcNow.AddMinutes(_jwtSettings.RefreshTokenExpiryInMinutes);
        
        var refreshTokenEntity = new RefreshToken
        {
            Token = refreshToken,
            Expires = refreshTokenLifetime,
            UserId = userId
        };
        
        _tokenRepository.Add(refreshTokenEntity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<RefreshToken> ValidateRefreshTokenAsync(string refreshToken)
    {
        var refreshTokenEntity = await _tokenRepository.FindOneAsync(new RefreshTokenSpecification(refreshToken)); 
        
        if (refreshTokenEntity == null)
            throw new EntityNotFoundException(nameof(RefreshToken), refreshToken);
        
        if (refreshTokenEntity.IsExpired)
            throw new RefreshTokenExpiredException(refreshToken);
        
        return refreshTokenEntity;
    }

    public async Task RevokeRefreshTokenAsync(string refreshToken)
    {
        var refreshTokenEntity = await _tokenRepository.FindOneAsync(new RefreshTokenSpecification(refreshToken))
                                 ?? throw new EntityNotFoundException(nameof(RefreshToken), refreshToken);
        _tokenRepository.Delete(refreshTokenEntity);
        await _unitOfWork.SaveChangesAsync();
    }

    private async Task<IList<Claim>> GetUserClaimListAsync(int userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString()) ?? throw new Exception("User not found");
        var roles = await _userManager.GetRolesAsync(user);
        
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email!),
        };
        
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        return claims;
    }
}