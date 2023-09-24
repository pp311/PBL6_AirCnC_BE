using AirCnC.Application.Services.Auth.Dtos;
using AirCnC.Domain.Constants;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Exceptions;
using AirCnC.Domain.Exceptions.Auth;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AirCnC.Application.Services.Auth;

public interface IAuthService
{
    Task<TokenDto> LoginAsync(LoginDto logInDto);
    Task SignUpAsync(SignUpDto signUpDto);
    Task<TokenDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto);
}

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AuthService(ITokenService tokenService,
                       UserManager<User> userManager,
                       IMapper mapper,
                       IUnitOfWork unitOfWork) 
    {
        _tokenService = tokenService;
        _userManager = userManager;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task SignUpAsync(SignUpDto signUpDto)
    {
        var isEmailExisted = await _userManager.FindByEmailAsync(signUpDto.Email) != null;
        if (isEmailExisted)
            throw new EmailAlreadyExistException(signUpDto.Email);
        var isUsernameExisted = await _userManager.FindByNameAsync(signUpDto.Username) != null;
        if (isUsernameExisted)
            throw new UsernameAlreadyExistException(signUpDto.Username);
        
        var user = new User
        {
            FullName = signUpDto.FullName,
            UserName = signUpDto.Username,
            Email = signUpDto.Email,
        };

        await _unitOfWork.BeginTransactionAsync();
        
        try
        {
            var result = await _userManager.CreateAsync(user, signUpDto.Password);
            if (!result.Succeeded)
                throw new UserCreateFailException(result.Errors.First().Description);   
            
            var addRoleResult = await _userManager.AddToRoleAsync(user, AppRole.User);
            if (!addRoleResult.Succeeded)
                throw new EntityNotFoundException("Role", AppRole.User);
            
            await _unitOfWork.CommitTransactionAsync();
        }
        catch
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }

    public async Task<TokenDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto)
    {
        var refreshTokenEntity = await _tokenService.ValidateRefreshTokenAsync(refreshTokenDto.RefreshToken);

        var user = await _userManager.FindByIdAsync(refreshTokenEntity.UserId.ToString());
        
        var tokenDto = new TokenDto
        {
            AccessToken = await _tokenService.GenerateAccessTokenAsync(user!.Id),
            RefreshToken = _tokenService.GenerateRefreshToken()
        };
        
        await _tokenService.RevokeRefreshTokenAsync(refreshTokenDto.RefreshToken);
        
        await _tokenService.AddRefreshTokenAsync(user.Id, tokenDto.RefreshToken);
        
        return tokenDto;
    }
    
    public async Task<TokenDto> LoginAsync(LoginDto logInDto)
    {
        var user = await _userManager.FindByNameAsync(logInDto.Identifier)
                   ?? await _userManager.FindByEmailAsync(logInDto.Identifier);
        
        if (user == null)
            throw new UserNotFoundException(logInDto.Identifier);
        
        var isValid = await _userManager.CheckPasswordAsync(user, logInDto.Password);
        if (!isValid)
            throw new InvalidPasswordException();
        
        var userDto = _mapper.Map<GetUserDto>(user);

        var tokenDto = new TokenDto
        {
            AccessToken = await _tokenService.GenerateAccessTokenAsync(user.Id),
            RefreshToken = _tokenService.GenerateRefreshToken(),
            User = userDto
        };
        
        await _tokenService.AddRefreshTokenAsync(user.Id, tokenDto.RefreshToken);
        
        return tokenDto;
    } 
}