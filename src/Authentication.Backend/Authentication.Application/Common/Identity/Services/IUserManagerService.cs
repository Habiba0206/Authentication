using Authentication.Application.Common.Identity.Models;

namespace Authentication.Application.Common.Identity.Services;

public interface IUserManagerService
{
    ValueTask<ICollection<UserDto>> GetUsersAsync(CancellationToken cancellationToken = default);
    ValueTask<UserDto> GetUserAsync(Guid userId, CancellationToken cancellationToken);
    ValueTask<UserDto> BlockUserAsync(Guid userId, CancellationToken cancellationToken = default);
    ValueTask<UserDto> UnblockUserAsync(Guid userId, CancellationToken cancellationToken = default);
    ValueTask<UserDto> DeleteAsync(UserDto userDto, CancellationToken cancellationToken = default);
}
