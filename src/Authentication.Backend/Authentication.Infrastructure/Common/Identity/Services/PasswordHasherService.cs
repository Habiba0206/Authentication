using Authentication.Application.Common.Identity.Services;

namespace Authentication.Infrastructure.Common.Identity.Services;

public class PasswordHasherService : IPasswordHasherService
{
    public string HashPassword(string password)
    => BCrypt.Net.BCrypt.HashPassword(password);

    public bool ValidatePassword(string password, string hash)
    => BCrypt.Net.BCrypt.Verify(password, hash);
}
