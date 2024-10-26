using Authentication.Application.Common.Identity.Models;
using Authentication.Application.Common.Identity.Services;
using Authentication.Domain.Entities;
using Authentication.Domain.Enums;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Infrastructure.Common.Identity.Services;

public class UserManagerService(IMapper mapper, IUserService userService) : IUserManagerService
{
    public async ValueTask<UserDto> BlockUserAsync(
        Guid userId, 
        CancellationToken cancellationToken = default)
    {
        var user = await userService.GetByIdAsync(userId, cancellationToken: cancellationToken);

        if(user.Status == Status.Blocked)
            throw new InvalidDataException("this user is already blocked");

        user.Status = Status.Blocked;

        await userService.UpdateAsync(user, cancellationToken: cancellationToken);

        return mapper.Map<UserDto>(user);
    }

    public async ValueTask<UserDto> DeleteAsync(UserDto userDto, CancellationToken cancellationToken = default)
    {
        var user = mapper.Map<User>(userDto);

        await userService.DeleteAsync(user, cancellationToken: cancellationToken);

        return userDto;
    }

    public async ValueTask<UserDto> GetUserAsync(Guid userId, CancellationToken cancellationToken) =>
    mapper.Map<UserDto>(await userService.GetByIdAsync(userId, cancellationToken: cancellationToken));

    public async ValueTask<ICollection<UserDto>> GetUsersAsync(CancellationToken cancellationToken = default) =>
    mapper.Map<ICollection<UserDto>>(await userService.Get().ToListAsync(cancellationToken));

    public async ValueTask<UserDto> UnblockUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await userService.GetByIdAsync(userId, cancellationToken: cancellationToken);

        if (user.Status == Status.Unblocked)
            throw new InvalidDataException("this user is already unblocked");

        user.Status = Status.Unblocked;

        await userService.UpdateAsync(user, cancellationToken: cancellationToken);

        return mapper.Map<UserDto>(user);
    }
}
