using Authentication.Application.Common.Identity.Models;

namespace Authentication.Application.Common.Identity.Services;

public interface IAuthService
{
    ValueTask<bool> Register(RegisterDetails registerDetails, CancellationToken cancellation = default);
    ValueTask<string> Login(LoginDetails loginDetails, CancellationToken cancellation = default);
}
