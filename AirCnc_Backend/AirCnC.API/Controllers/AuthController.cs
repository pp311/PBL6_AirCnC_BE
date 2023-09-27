using AirCnC.Application.Services.Auth;
using AirCnC.Application.Services.Auth.Dtos;
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
		await _authenticateService.SignUpAsync(signUpDto);
		return Ok();
	}
        
	[HttpPost("log-in")]
	public async Task<IActionResult> Login([FromBody] LoginDto logInDto)
	{
		var result = await _authenticateService.LoginAsync(logInDto);
		return Ok(result);
	}
        
	[HttpPost("refresh-token")]
	public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
	{
		var result = await _authenticateService.RefreshTokenAsync(refreshTokenDto);
		return Ok(result);
	}
	
	[HttpPost("refresh-token/revoke")]
	public async Task<IActionResult> RevokeRefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
	{
		await _tokenService.RevokeRefreshTokenAsync(refreshTokenDto.RefreshToken);
		return Ok();
	}
	
	[HttpPost("google-login")]
	public async Task<IActionResult> GoogleLoginAsync(ExternalAuthDto dto)
	{
		var result = await _authenticateService.GoogleAuthenticateAsync(dto);
		return Ok(result);
	}
}