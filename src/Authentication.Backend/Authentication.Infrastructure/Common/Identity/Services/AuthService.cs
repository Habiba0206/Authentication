using Authentication.Application.Common.Identity.Models;
using Authentication.Application.Common.Identity.Services;
using Authentication.Application.Common.Notifications.Servcies;
using Authentication.Domain.Entities;
using Authentication.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;

namespace Authentication.Infrastructure.Common.Identity.Services;

public class AuthService : IAuthService
{
    private readonly ITokenGeneratorService _tokenGenerateService;
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly IAccountService _accountService;
    private readonly IEmailOrchestrationService _emailOrchestrationService;
    private readonly IAccessTokenService _tokenService;
    private readonly IUserService _userService;
    
    public AuthService
        (
        ITokenGeneratorService token,
        IPasswordHasherService passwordHasherService,
        IAccountService accountService,
        IEmailOrchestrationService emailOrchestrationService,
        IAccessTokenService tokenService,
        IUserService userService
        )
    {
        _tokenGenerateService = token;
        _passwordHasherService = passwordHasherService;
        _accountService = accountService;
        _emailOrchestrationService = emailOrchestrationService;
        _tokenService = tokenService;
        _userService = userService;
        
    }
    public async ValueTask<bool> Register(RegisterDetails registerDetails, CancellationToken cancellation = default)
    {
        var foundUser = await _userService.GetByEmailAsync(registerDetails.EmailAddress, true, cancellation);

        if (foundUser is not null)
            throw new InvalidOperationException("User with this email address already exists.");

        //password validation:
        if(string.IsNullOrWhiteSpace(registerDetails.EmailAddress)) 
            throw new InvalidDataException("Invalid password");

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = registerDetails.FirstName,
            LastName = registerDetails.LastName,
            Age = registerDetails.Age,
            EmailAddress = registerDetails.EmailAddress,
            PasswordHash = _passwordHasherService.HashPassword(registerDetails.Password),
            Status = Status.Unblocked
        };

        var createdUser = await _accountService.CreateAsync(user);
        //var verificationEmailResult = await _emailOrchestrationService.SendAsync(user.EmailAddress, "Sistemaga xush kelibsiz!");

        return createdUser is not null;
    }
    public async ValueTask<string> Login(LoginDetails loginDetails, CancellationToken cancellation = default)
    {
        var foundUser = await _userService.GetByEmailAsync(loginDetails.EmailAddress, true, cancellation) ?? throw new AuthenticationException("Email is invalid");

        if(foundUser.Status == Status.Blocked)
            throw new AuthenticationException("This user is blocked");

        if (!_passwordHasherService.ValidatePassword(loginDetails.Password, foundUser.PasswordHash))
        {
            throw new AuthenticationException("Password is invalid");
        }

        var token = _tokenGenerateService.GetToken(foundUser);

        var accestoken = _tokenService.Get(t => t.UserId == foundUser.Id).FirstOrDefaultAsync(cancellation);
        
        if(accestoken is null)
            await _tokenService.CreateAsync(foundUser.Id, token);

        return new(token);
    }

} 
