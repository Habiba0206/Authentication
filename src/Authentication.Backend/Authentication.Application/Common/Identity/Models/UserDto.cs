using Authentication.Domain.Enums;

namespace Authentication.Application.Common.Identity.Models;

public class UserDto
{
    public Guid? Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string EmailAddress { get; set; }
    public Status Status { get; set; }
}
