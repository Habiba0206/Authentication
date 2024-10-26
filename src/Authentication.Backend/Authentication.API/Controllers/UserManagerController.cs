using Authentication.Application.Common.Identity.Models;
using Authentication.Application.Common.Identity.Services;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers;
[ApiController]
[Route("api/[controller]")]

public class UserManagerController(IUserManagerService userManagerService) : ControllerBase
{
    [HttpPut("Block/{userId:guid}")]
    public async ValueTask<IActionResult> Block([FromRoute] Guid userId, CancellationToken cancellationToken)
    {
        var result = await userManagerService.BlockUserAsync(userId, cancellationToken);

        return Ok(result);
    }

    [HttpPut("Unblock/{userId:guid}")]
    public async ValueTask<IActionResult> Unblock([FromRoute] Guid userId, CancellationToken cancellationToken)
    {
        var result = await userManagerService.UnblockUserAsync(userId, cancellationToken);

        return Ok(result);
    }

    [HttpDelete]
    public async ValueTask<IActionResult> Delete([FromBody] UserDto userDto, CancellationToken cancellationToken)
    {
        var result = await userManagerService.DeleteAsync(userDto, cancellationToken);

        return result is not null ? Ok() : BadRequest();
    }

    [HttpGet]
    public async ValueTask<IActionResult> Get(CancellationToken cancellationToken)
    {
        var result = await userManagerService.GetUsersAsync(cancellationToken);

        return result.Any() ? Ok(result) : NoContent();
    }

    [HttpGet("{userId:guid}")]
    public async ValueTask<IActionResult> GetUser([FromRoute] Guid userId, CancellationToken cancellationToken)
    {
        var result = await userManagerService.GetUserAsync(userId, cancellationToken);
        Console.WriteLine(result is null);

        return result is not null ? Ok(result) : NoContent();
    }
}
