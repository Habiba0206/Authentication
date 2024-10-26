using Authentication.Application.Common.Identity.Models;
using Authentication.Application.Common.Identity.Services;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers;
[ApiController]
[Route("api/[controller]")]

public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Register")]
    public async ValueTask<IActionResult> Register([FromBody] RegisterDetails registerDetails, CancellationToken cancellationToken)
    {
        var data = await _authService.Register(registerDetails);
        return data ? Ok(data) : BadRequest();
    }

    [HttpPost("Login")]
    public async ValueTask<IActionResult> Login([FromBody] LoginDetails loginDetails, CancellationToken cancellationToken)
    {
        var data = await _authService.Login(loginDetails);
        return data != null ? Ok(data) : NotFound();
    }
}
