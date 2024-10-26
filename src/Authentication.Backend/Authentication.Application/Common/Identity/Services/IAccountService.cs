using Authentication.Domain.Entities;

namespace Authentication.Application.Common.Identity.Services;

public interface IAccountService
{
    ValueTask<bool> VerficateAsync(string token);
    ValueTask<User> CreateAsync(User user);
}
