using AirCnC.Application.Services.Auth;
using AirCnC.Application.Services.Auth.Dtos;
using AirCnC.Domain.Constants;
using Microsoft.AspNetCore.Mvc;

namespace AirCnC.API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
	private readonly IAuthService _authenticateService;
	private readonly ITokenService _tokenService;
	public AuthController(
		IAuthService authenticateService,
		ITokenService tokenService)
	{
		_authenticateService = authenticateService;
		_tokenService = tokenService;
	}

	[HttpPost("sign-up")]
	public async Task<IActionResult> SignUpAsync([FromBody] SignUpDto signUpDto)
	{
		var user = await _authenticateService.SignUpAsync(signUpDto);
		return Ok(user);
	}
        
	[HttpPost("admin/log-in")]
	public async Task<IActionResult> Login([FromBody] LoginDto logInDto)
	{
		var result = await _authenticateService.LoginAsync(logInDto, AppRole.Admin);
		return Ok(result);
	}
	
	[HttpPost("user/log-in")]
	public async Task<IActionResult> UserLogin([FromBody] LoginDto logInDto)
	{
		var result = await _authenticateService.LoginAsync(logInDto, AppRole.User);
		return Ok(result);
	}
        
	/// <summary>
	/// Dùng để refresh token, khi token hết hạn thì dùng refresh token để lấy access token và refresh token mới
	/// </summary>
	[HttpPost("refresh-token")]
	public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
	{
		var result = await _authenticateService.RefreshTokenAsync(refreshTokenDto);
		return Ok(result);
	}
	
	/// <summary>
	/// Dùng để logout, khi logout thì sẽ xóa refresh token
	/// </summary>
	[HttpPost("refresh-token/revoke")]
	public async Task<IActionResult> RevokeRefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
	{
		await _tokenService.RevokeRefreshTokenAsync(refreshTokenDto.RefreshToken);
		return Ok();
	}
	
	/// <summary>
	/// Khi đăng nhập bằng google sẽ có access token của google trả về, dùng AC đó thay cho password để đăng nhập, nếu chưa có tài khoản thì sẽ tạo mới
	/// </summary>
	[HttpPost("google-login")]
	public async Task<IActionResult> GoogleLoginAsync(ExternalAuthDto dto)
	{
		var result = await _authenticateService.GoogleAuthenticateAsync(dto);
		return Ok(result);
	}
}