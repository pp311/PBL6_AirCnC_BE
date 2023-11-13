using AirCnC.Application.Commons.Specifications;
using AirCnC.Application.Services.Auth.Dtos;
using AirCnC.Domain.Constants;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Exceptions;
using AirCnC.Domain.Exceptions.Auth;
using AutoMapper;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2;
using Google.Apis.Oauth2.v2.Data;
using Google.Apis.Services;
using Microsoft.AspNetCore.Identity;

namespace AirCnC.Application.Services.Auth;

public interface IAuthService
{
    Task<TokenDto> LoginAsync(LoginDto logInDto, string role);
    Task<GetUserDto> SignUpAsync(SignUpDto signUpDto);
    Task<TokenDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto);
    Task<TokenDto> GoogleAuthenticateAsync(ExternalAuthDto dto);
}

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<Guest> _guestRepository;
    private readonly IRepository<Host> _hostRepository;

    public AuthService(ITokenService tokenService,
                       UserManager<User> userManager,
                       IMapper mapper,
                       IUnitOfWork unitOfWork,
                       IRepository<Guest> guestRepository,
                       IRepository<Host> hostRepository)
    {
        _tokenService = tokenService;
        _userManager = userManager;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _guestRepository = guestRepository;
        _hostRepository = hostRepository;
    }
    public async Task<GetUserDto> SignUpAsync(SignUpDto signUpDto)
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
            // Create the user
            var result = await _userManager.CreateAsync(user, signUpDto.Password);
            if (!result.Succeeded)
                throw new UserCreateFailException(result.Errors.First().Description);

            // Add role to user
            var addRoleResult = await _userManager.AddToRoleAsync(user, AppRole.User);
            if (!addRoleResult.Succeeded)
                throw new EntityNotFoundException("Role", AppRole.User);

            // Make user a guest
            _guestRepository.Add(new Guest { UserId = user.Id });
            await _unitOfWork.SaveChangesAsync();

            await _unitOfWork.CommitTransactionAsync();
        }
        catch
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
        
        return _mapper.Map<GetUserDto>(user);
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

    public async Task<TokenDto> GoogleAuthenticateAsync(ExternalAuthDto dto)
    {
        // get user info from access token
        var userInfo = await new Oauth2Service(new BaseClientService.Initializer
        {
            HttpClientInitializer = GoogleCredential.FromAccessToken(dto.AccessToken),
            ApplicationName = "AirCnC"
        }).Userinfo.Get().ExecuteAsync();

        var user = await GetOrCreateUserAsync(userInfo);

        var tokenDto = new TokenDto
        {
            AccessToken = await _tokenService.GenerateAccessTokenAsync(user.Id),
            RefreshToken = _tokenService.GenerateRefreshToken(),
            User = _mapper.Map<GetUserDto>(user)
        };

        await _tokenService.AddRefreshTokenAsync(user.Id, tokenDto.RefreshToken);

        return tokenDto;
    }

    public async Task<TokenDto> LoginAsync(LoginDto logInDto, string role)
    {
        var user = await _userManager.FindByNameAsync(logInDto.Identifier)
                   ?? await _userManager.FindByEmailAsync(logInDto.Identifier);

        if (user == null)
            throw new UserNotFoundException(logInDto.Identifier);

        var isAdmin = await _userManager.IsInRoleAsync(user, AppRole.Admin);
        switch (role)
        {
            case AppRole.Admin when !isAdmin:
                throw new UserNotFoundException(logInDto.Identifier);
            case AppRole.User when isAdmin:
                throw new UserNotFoundException(logInDto.Identifier);
        }


        var isValid = await _userManager.CheckPasswordAsync(user, logInDto.Password);
        if (!isValid)
            throw new InvalidPasswordException();

        var userDto = _mapper.Map<GetUserDto>(user);
        userDto.IsHost = await _hostRepository.AnyAsync(new HostByUserIdSpecification(user.Id));
        
        var tokenDto = new TokenDto
        {
            AccessToken = await _tokenService.GenerateAccessTokenAsync(user.Id),
            RefreshToken = _tokenService.GenerateRefreshToken(),
            User = userDto
        };
        
        await _tokenService.AddRefreshTokenAsync(user.Id, tokenDto.RefreshToken);

        return tokenDto;
    }

    private async Task<User> GetOrCreateUserAsync(Userinfo payload)
    {
        var user = await _userManager.FindByEmailAsync(payload.Email);
        if (user != null) return user;

        user = new User
        {
            Email = payload.Email,
            UserName = payload.Email,
            FullName = payload.Name,
            EmailConfirmed = true,
            AvatarUrl = payload.Picture
        };

        await _unitOfWork.BeginTransactionAsync();

        // UserManager mac dinh sau khi goi ham se save luon, neu goi nhieu ham cua UserManager thi can dung transaction
        // de dam bao du lieu duoc luu khi tat ca cac ham duoc goi thanh cong
        try
        {
            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
                throw new UserCreateFailException(result.Errors.First().Description);

            var addRoleResult = await _userManager.AddToRoleAsync(user, AppRole.User);
            if (!addRoleResult.Succeeded)
                throw new UserCreateFailException(result.Errors.First().Description);

            _guestRepository.Add(new Guest { UserId = user.Id });
            await _unitOfWork.SaveChangesAsync();

            await _unitOfWork.CommitTransactionAsync();
        }
        catch
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }

        return user;
    }
}
