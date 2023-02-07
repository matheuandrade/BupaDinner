namespace BupaDinner.Api.Controllers;

using BupaDinner.Application.Services.Authentication;
using BupaDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase 
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var registerResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        var response = new AuthenticationResponse(registerResult.Id,
            registerResult.FirstName,
            registerResult.LastName,
            registerResult.Email,
            registerResult.Token);

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var loginResult = _authenticationService.Login(
            request.Email,
            request.Password);

        var response = new AuthenticationResponse(loginResult.Id,
            loginResult.FirstName,
            loginResult.LastName,
            loginResult.Email,
            loginResult.Token);

        return Ok(response);
    }
}